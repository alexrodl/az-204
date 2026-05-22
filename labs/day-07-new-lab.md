# Laboratorio AZ-204  
# ASP.NET Core + Azure App Configuration + Azure Key Vault

---

# Objetivo

En este laboratorio construiremos una aplicación web ASP.NET Core 8 que:

- Consume configuraciones desde Azure App Configuration
- Consume secretos desde Azure Key Vault
- Utiliza Feature Flags
- Utiliza autenticación moderna con DefaultAzureCredential
- Simula un escenario real de aplicación empresarial

---

# Escenario

Una empresa necesita centralizar la configuración de sus aplicaciones y almacenar secretos de forma segura.

Actualmente:
- usan `appsettings.json`
- tienen secretos hardcodeados
- deben redeployar para cambiar configuraciones

La solución será:
- Azure App Configuration
- Azure Key Vault
- Managed Identity

---

# Arquitectura

| Servicio | Propósito |
|---|---|
| ASP.NET Core 8 | Aplicación web |
| Azure App Configuration | Configuración centralizada |
| Azure Key Vault | Almacenamiento seguro de secretos |
| DefaultAzureCredential | Autenticación moderna |
| Feature Flags | Habilitación dinámica de funcionalidades |

---

# Requisitos

## Tener instalado

- .NET 8 SDK
- Azure CLI
- Visual Studio 2022 o VS Code
- Cuenta Azure

---

# Paso 1 - Login Azure

```powershell
az login
```

---

# Paso 3 - Crear Resource Group

```powershell
$resourceGroup = "rg-az204-lab"
az group create --name $resourceGroup --location eastus2
```

---

# Paso 4 - Crear Azure App Configuration

```powershell
$random = Get-Random -Maximum 99999
$appconfigName = "ac-204-$random"

az appconfig create `
  --name $appconfigName `
  --resource-group $resourceGroup `
  --location eastus2 `
  --sku free
```

---

# Paso 5 - Crear Azure Key Vault

```powershell
$random = Get-Random -Maximum 99999

$keyVaultName = "kv-az204-$random"

az keyvault create `
  --name $keyVaultName `
  --resource-group $resourceGroup `
  --location eastus2

$userPrincipal=$(az rest --method GET --url https://graph.microsoft.com/v1.0/me --headers 'Content-Type=application/json' --query userPrincipalName --output tsv)

$resourceID=$(az keyvault show --resource-group $resourceGroup --name $keyVaultName --query id --output tsv)

az role assignment create --assignee $userPrincipal --role "Key Vault Secrets Officer" --scope $resourceID
```

---

# Paso 6 - Crear secretos en Key Vault

## Crear ApiKey

```powershell
az keyvault secret set `
  --vault-name $keyVaultName `
  --name ApiKey `
  --value "super-secret-api-key"
```

## Crear SqlPassword

```powershell
az keyvault secret set `
  --vault-name $keyVaultName `
  --name SqlPassword `
  --value "P@ssw0rd123"
```

## Crear StorageConnection

```powershell
az keyvault secret set `
  --vault-name $keyVaultName `
  --name StorageConnection `
  --value "DefaultEndpointsProtocol=https;AccountName=fake"
```

---

# Paso 7 - Crear configuraciones en App Configuration

## Crear App:Title

```powershell
az appconfig kv set `
  --name $appconfigName `
  --key "App:Title" `
  --value "Portal Web"
```

## Crear App:Theme

```powershell
az appconfig kv set `
  --name $appconfigName `
  --key "App:Theme" `
  --value "Dark"
```

## Crear App:WelcomeMessage

```powershell
az appconfig kv set `
  --name $appconfigName `
  --key "App:WelcomeMessage" `
  --value "Welcome to Azure AZ-204 Lab"

az appconfig kv set-keyvault `
  --name $appConfigName `
  --key "ApiKey" `
  --secret-identifier "https://$keyVaultName.vault.azure.net/secrets/ApiKey"

az appconfig kv set-keyvault `
  --name $appConfigName `
  --key "SqlPassword" `
  --secret-identifier "https://$keyVaultName.vault.azure.net/secrets/SqlPassword"

az appconfig kv set-keyvault `
  --name $appConfigName `
  --key "StorageConnection" `
  --secret-identifier "https://$keyVaultName.vault.azure.net/secrets/StorageConnection"
```

---

# Paso 8 - Crear Feature Flag

```powershell
az appconfig feature set `
  --name $appconfigName `
  --feature BetaPage `
  --yes
```

---

# Paso 9 - Crear proyecto ASP.NET Core MVC

```powershell
dotnet new mvc -n Az204.KeyVaultLab -f net8.0
```

---

# Paso 10 - Abrir proyecto

```powershell
cd Az204.KeyVaultLab
```

---

# Paso 11 - Abrir Visual Studio Code

```powershell
code .
```

---

# Paso 12 - Instalar paquetes NuGet

```powershell
dotnet add package Azure.Identity
```

```powershell
dotnet add package Microsoft.Extensions.Configuration.AzureAppConfiguration
```

```powershell
dotnet add package Azure.Security.KeyVault.Secrets
```

```powershell
dotnet add package Azure.Extensions.AspNetCore.Configuration.Secrets
```

```powershell
dotnet add package Microsoft.FeatureManagement.AspNetCore
```

```powershell
dotnet add package Microsoft.Azure.AppConfiguration.AspNetCore
```
---

# Paso 13 - Configurar Program.cs

## Reemplazar el contenido completo de Program.cs

```csharp
using Azure.Identity;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(
        new Uri("https://ac-204-81327.azconfig.io"),
        new DefaultAzureCredential())
    .ConfigureKeyVault(kv =>
    {
        kv.SetCredential(new DefaultAzureCredential());
    })
    .ConfigureRefresh(refresh =>
    {
        refresh.Register("App:Sentinel", refreshAll: true)
               .SetRefreshInterval(TimeSpan.FromSeconds(30));
    })
    .Select("App:*", "Development")
    .UseFeatureFlags();
});

builder.Services.AddControllersWithViews();

builder.Services.AddAzureAppConfiguration();

builder.Services.AddFeatureManagement();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAzureAppConfiguration();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

---

# Paso 14 - Explicación importante

## ¿Qué hace DefaultAzureCredential?

DefaultAzureCredential intenta autenticarse utilizando:

1. Visual Studio
2. Azure CLI
3. Azure PowerShell
4. Managed Identity
5. Variables de entorno

---

# Paso 19 - Modificar HomeController

## Archivo

```txt
Controllers/HomeController.cs
```

## Reemplazar contenido

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace Az204.KeyVaultLab.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IFeatureManager _featureManager;

    public HomeController(
        IConfiguration configuration,
        IFeatureManager featureManager)
    {
        _configuration = configuration;
        _featureManager = featureManager;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.WebTitle = _configuration["App:WebTitle"];

        ViewBag.Theme = _configuration["App:Theme"];

        ViewBag.Message = _configuration["App:WelcomeMessage"];

        ViewBag.ApiKey = _configuration["ApiKey"];

        ViewBag.SqlPassword = _configuration["SqlPassword"];

        ViewBag.StorageConnection = _configuration["StorageConnection"];

        ViewBag.BetaEnabled = await _featureManager.IsEnabledAsync("BetaPage");

        return View();
    }
}

```

---

# Paso 20 - Modificar View

## Archivo

```txt
Views/Home/Index.cshtml
```

## Reemplazar contenido

```html
@{
    ViewData["Title"] = "Azure Lab";
}

<div class="text-center">

    <h1>@ViewBag.WebTitle</h1>

    <h3>@ViewBag.Message</h3>

    <hr />

    <h4>Application Configuration</h4>

    <p>
        <strong>Theme:</strong>
        @ViewBag.Theme
    </p>

    <hr />

    <h4>Secrets from Key Vault</h4>

    <p>
        <strong>ApiKey:</strong>
        @ViewBag.ApiKey
    </p>

    <p>
        <strong>SqlPassword:</strong>
        @ViewBag.SqlPassword
    </p>

    <p>
        <strong>StorageConnection:</strong>
        @ViewBag.StorageConnection
    </p>

    <hr />

    @if (ViewBag.BetaEnabled)
    {
        <div class="alert alert-success">
            Beta Feature Enabled!
        </div>
    }
    else
    {
        <div class="alert alert-danger">
            Beta Feature Disabled
        </div>
    }

</div>
```

---

# Paso 21 - Ejecutar aplicación

```powershell
dotnet run
```

---

# Paso 22 - Abrir navegador

Abrir:

```txt
https://localhost:xxxx
```

---

# Resultado esperado

La aplicación deberá mostrar:

- Configuraciones desde App Configuration
- Secretos desde Key Vault
- Estado del Feature Flag

---

# Demo 1 - Cambiar configuración dinámica

## Ir a Azure App Configuration

Modificar:

```txt
App:WelcomeMessage
```

## Nuevo valor

```txt
Hello from Azure App Configuration!
```

---

# Refrescar aplicación

Verificar que cambia el mensaje.

---

# Demo 2 - Feature Flags

## Ir a Azure App Configuration

Desactivar:

```txt
BetaPage
```

---

# Refrescar aplicación

Verificar que desaparece la funcionalidad beta.

---

# Demo 3 - Rotación de secretos

## Ir a Azure Key Vault

Modificar:

```txt
ApiKey
```

## Nuevo valor

```txt
new-production-api-key
```

---

# Refrescar aplicación

Verificar que el valor cambió sin modificar código.

---

# Bonus - Deploy en Azure App Service

# Paso 23 - Crear App Service

```powershell
$random = Get-Random -Maximum 99999
$webAppName = "az204-webapp-$random"
az webapp up --name $webAppName --resource-group $resourceGroup --runtime "dotnet:8" --sku B1
```

---

# Paso 24 - Habilitar Managed Identity

```powershell
az webapp identity assign --name $webAppName --resource-group $resourceGroup
```

---

# Paso 26 - Dar permisos a Managed Identity en Key Vault

```powershell
$webAppPrincipalId = az webapp identity show --name $webAppName --resource-group $resourceGroup --query principalId -o tsv

$keyVaultId = az keyvault show --name $keyVaultName --query id -o tsv

az role assignment create --role "Key Vault Secrets User" --assignee $webAppPrincipalId --scope $keyVaultId
```

---

# Paso 27 - Dar permisos a Managed Identity en App Configuration

```powershell
$appConfigId = az appconfig show --name $appConfigName --query id -o tsv

az role assignment create --role "App Configuration Data Reader" --assignee $webAppPrincipalId --scope $appConfigId
```

---

# Conceptos AZ-204 cubiertos

- Azure App Configuration
- Azure Key Vault
- Feature Flags
- Managed Identity
- RBAC
- DefaultAzureCredential
- ASP.NET Core Configuration
- Cloud Native Applications

---

# Limpieza de recursos

```powershell
az group delete `
  --name rg-az204-lab `
  --yes
```

---

# Fin del laboratorio
