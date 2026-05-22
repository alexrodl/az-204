# 🧪 Ejemplos - Application Insights en .NET 8

## 🎯 Objetivos

- Comparar distintas formas de integrar Application Insights
- Comprender diferencias entre:
  - integración automática
  - SDK Application Insights
  - OpenTelemetry
- Visualizar telemetría en Azure

---

# 📌 Escenario base

En los 3 ejemplos vamos a:

- crear una aplicación ASP.NET Core MVC
- publicarla en Azure App Service
- configurar Application Insights
- generar tráfico
- visualizar telemetría

---

# ⚖️ Comparación rápida

| Método | Código requerido | Nivel de control | Recomendado |
|--------|------------------|------------------|-------------|
| App Service Integration | mínimo | básico | demos/labs |
| Application Insights SDK | medio | alto | apps tradicionales |
| OpenTelemetry | medio/alto | muy alto | aplicaciones modernas |

---

# 🧪 Ejemplo 1 - App Service + Application Insights automático

## 🎯 Objetivo

Habilitar monitoreo SIN modificar código.

---

# 🏗️ Paso 1 - Crear aplicación MVC

```bash
dotnet new mvc -n DemoMvcApp
```

---

# ▶️ Paso 2 - Ejecutar localmente

```bash
dotnet run
```

---

# ☁️ Paso 3 - Publicar en Azure App Service

Publicar usando:
- Visual Studio
o
- Azure CLI

---

# 📊 Paso 4 - Habilitar Application Insights

Ir a:

```text
App Service
→ Application Insights
→ Turn On
```

---

# 🔥 Resultado

Azure comenzará a recopilar automáticamente:

- requests
- performance
- failures
- logs básicos

---

# ✅ Ventajas

- extremadamente simple
- sin cambios de código
- ideal para demos

---

# ⚠️ Limitaciones

- menor control
- menos telemetría personalizada

---

# 🧪 Qué mostrar

## Requests
Requests HTTP recibidos.

---

## Live Metrics
Métricas en tiempo real.

---

## Failures
Errores y excepciones.

---

# 🧪 Ejemplo 2 - Application Insights usando SDK

## 🎯 Objetivo

Agregar telemetría mediante librerías oficiales.

---

# 🏗️ Paso 1 - Crear aplicación MVC

```bash
dotnet new mvc -n DemoMvcSdk
```

---

# 📦 Paso 2 - Instalar paquete

```bash
dotnet add package Microsoft.ApplicationInsights.AspNetCore
```

---

# ⚙️ Paso 3 - Configurar Program.cs

```csharp
builder.Services.AddApplicationInsightsTelemetry();
```

---

# 🔑 Paso 4 - Agregar Connection String

```json
{
  "ApplicationInsights": {
    "ConnectionString": "InstrumentationKey=xxxxx"
  }
}
```

---

# 💡 Paso 5 - Agregar logging personalizado

## HomeController.cs

```csharp
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Home page visited");

        return View();
    }
}
```

---

# 💥 Paso 6 - Crear endpoint con error

```csharp
app.MapGet("/error", () =>
{
    throw new Exception("Demo exception");
});
```

---

# ☁️ Paso 7 - Publicar en App Service

Publicar aplicación.

---

# 🔥 Resultado

Application Insights recopilará:

- requests
- exceptions
- logs personalizados
- dependencies
- traces

---

# ✅ Ventajas

- mayor control
- custom telemetry
- integración profunda

---

# ⚠️ Limitaciones

- requiere cambios de código
- dependiente del SDK Microsoft

---

# 🧪 Qué mostrar

## Logs personalizados

```text
Home page visited
```

---

## Exceptions

Endpoint:
```text
/error
```

---

## Requests

Tiempo de respuesta y performance.

---

# 🧪 Ejemplo 3 - OpenTelemetry + Azure Monitor

## 🎯 Objetivo

Usar estándar moderno de observabilidad.

---

# 🏗️ Paso 1 - Crear aplicación MVC

```bash
dotnet new mvc -n DemoMvcOtel
```

---

# 📦 Paso 2 - Instalar paquetes

```bash
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore
```

---

# ⚙️ Paso 3 - Configurar Program.cs

```csharp
using Azure.Monitor.OpenTelemetry.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry()
    .UseAzureMonitor();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
```

---

# 🔑 Paso 4 - Configurar Connection String

```json
{
  "APPLICATIONINSIGHTS_CONNECTION_STRING":
  "InstrumentationKey=xxxxx"
}
```

---

# 💡 Paso 5 - Agregar logging

```csharp
app.MapGet("/products", (ILogger<Program> logger) =>
{
    logger.LogInformation("Getting products");

    return Results.Ok();
});
```

---

# 💥 Paso 6 - Agregar error demo

```csharp
app.MapGet("/error", () =>
{
    throw new Exception("OpenTelemetry demo error");
});
```

---

# ☁️ Paso 7 - Publicar en Azure App Service

Publicar aplicación.

---

# 🔥 Resultado

Azure Monitor recibirá:

- traces
- metrics
- logs
- distributed telemetry

---

# ✅ Ventajas

- estándar abierto
- vendor-neutral
- observabilidad moderna
- portable

---

# ⚠️ Importante

Microsoft recomienda OpenTelemetry para nuevos proyectos.

---

# 🧪 Qué mostrar

## Requests
Requests HTTP.

---

## Exceptions
Errores y stack traces.

---

## Distributed Tracing
Seguimiento de requests.

---

# 📌 Comparación final

| Característica | App Service | SDK | OpenTelemetry |
|---------------|-------------|-----|----------------|
| Cambios código | ❌ | ✅ | ✅ |
| Custom telemetry | limitada | alta | muy alta |
| Vendor-neutral | ❌ | ❌ | ✅ |
| Facilidad | muy simple | media | media |
| Moderno | medio | medio | alto |

---

# 🔥 Conclusión

## App Service Integration
Ideal para:
- demos
- labs
- monitoreo rápido

---

## SDK Application Insights
Ideal para:
- aplicaciones existentes
- custom telemetry

---

## OpenTelemetry
Ideal para:
- aplicaciones modernas
- microservicios
- observabilidad enterprise

---

# 🗣️ Preguntas para la clase

- ¿Qué ventajas tiene OpenTelemetry?
- ¿Cuándo usarían integración automática?
- ¿Por qué agregar telemetría personalizada?
- ¿Qué diferencia hay entre logs y métricas?