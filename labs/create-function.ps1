$ErrorActionPreference = "Stop"
$RG = "myResourceGroup"
$LOCATION = "centralus"
$random = Get-Random -Minimum 1000 -Maximum 9999
$FUNCTION_APP = "func-az204-$random"
## Create a function app plan

az functionapp plan create `
  --resource-group $RG `
  --name plan-az204 `
  --location $LOCATION `
  --sku Y1

## Create a function app plan
  az functionapp create `
  --resource-group $RG `
  --name $FUNCTION_APP `
  --storage-account "storage-account-$FUNCTION_APP" `
  --consumption-plan-location $LOCATION `
  --runtime dotnet-isolated `
  --functions-version 4

## Habilitar Managed Identity
  az functionapp identity assign `
  --name $FUNCTION_APP `
  --resource-group $RG

## Obtener principalId
$PRINCIPAL_ID=$(az functionapp identity show `
  --name $FUNCTION_APP `
  --resource-group $RG `
  --query principalId `
  -o tsv)

## Obtener Storage Queue resource id
$QUEUE_STORAGE_ID=$(az storage account show `
  --name $QUEUE_STORAGE `
  --resource-group $RG `
  --query id `
  -o tsv)

  # Dar permisos RBAC
az role assignment create `
  --assignee $PRINCIPAL_ID `
  --role "Storage Queue Data Contributor" `
  --scope $QUEUE_STORAGE_ID

  # App setting para binding
az functionapp config appsettings set `
  --name $FUNCTION_APP `
  --resource-group $RG `
  --settings `
  ImagesStorage__queueServiceUri=https://$QUEUE_STORAGE.queue.core.windows.net