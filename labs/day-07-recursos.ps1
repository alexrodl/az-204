#az login

$resourceGroup = "rg-az204-lab"
az group create --name $resourceGroup --location eastus2

$random = Get-Random -Maximum 99999
$appconfigName = "ac-204-$random"

az appconfig create `
  --name $appconfigName `
  --resource-group $resourceGroup `
  --location eastus2 `
  --sku free

$random = Get-Random -Maximum 99999

$keyVaultName = "kv-az204-$random"

az keyvault create `
  --name $keyVaultName `
  --resource-group $resourceGroup `
  --location eastus2

$userPrincipal=$(az rest --method GET --url https://graph.microsoft.com/v1.0/me --headers 'Content-Type=application/json' --query userPrincipalName --output tsv)

$resourceID=$(az keyvault show --resource-group $resourceGroup --name $keyVaultName --query id --output tsv)

az role assignment create --assignee $userPrincipal --role "Key Vault Secrets Officer" --scope $resourceID

az keyvault secret set `
  --vault-name $keyVaultName `
  --name ApiKey `
  --value "super-secret-api-key"

az keyvault secret set `
  --vault-name $keyVaultName `
  --name SqlPassword `
  --value "P@ssw0rd123"

az keyvault secret set `
  --vault-name $keyVaultName `
  --name StorageConnection `
  --value "DefaultEndpointsProtocol=https;AccountName=fake"

az appconfig kv set `
  --name $appconfigName `
  --key "App:Title" `
  --value "Portal Web"

az appconfig kv set `
  --name $appconfigName `
  --key "App:Theme" `
  --value "Dark"

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

az appconfig feature set `
  --name $appconfigName `
  --feature BetaPage `
  --yes

$random = Get-Random -Maximum 99999
$webAppName = "az204-webapp-$random"
az webapp up --name $webAppName --resource-group $resourceGroup --runtime "dotnet:8" --sku B1

az webapp identity assign --name $webAppName --resource-group $resourceGroup

$webAppPrincipalId = az webapp identity show --name $webAppName --resource-group $resourceGroup --query principalId -o tsv

$keyVaultId = az keyvault show --name $keyVaultName --query id -o tsv

az role assignment create --role "Key Vault Secrets User" --assignee $webAppPrincipalId --scope $keyVaultId

$appConfigId = az appconfig show --name $appConfigName --query id -o tsv

az role assignment create --role "App Configuration Data Reader" --assignee $webAppPrincipalId --scope $appConfigId