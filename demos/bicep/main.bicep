@description('Location for all resources')
param location string = resourceGroup().location

@description('Function App name')
param functionAppName string

@description('Runtime storage account name')
param runtimeStorageAccountName string

@description('Queue storage account name (existing)')
param queueStorageAccountName string

@description('Hosting plan name')
param hostingPlanName string = 'plan-az204'

@description('Functions runtime')
param functionsWorkerRuntime string = 'dotnet-isolated'

@description('Functions version')
param functionsExtensionVersion string = '~4'

/*
|--------------------------------------------------------------------------
| Existing Queue Storage
|--------------------------------------------------------------------------
*/
resource queueStorage 'Microsoft.Storage/storageAccounts@2023-05-01' existing = {
  name: queueStorageAccountName
}

/*
|--------------------------------------------------------------------------
| Runtime Storage Account
|--------------------------------------------------------------------------
*/
resource runtimeStorage 'Microsoft.Storage/storageAccounts@2023-05-01' = {
  name: runtimeStorageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
    allowBlobPublicAccess: false
    minimumTlsVersion: 'TLS1_2'
  }
}

/*
|--------------------------------------------------------------------------
| Function App Consumption Plan
|--------------------------------------------------------------------------
*/
resource hostingPlan 'Microsoft.Web/serverfarms@2023-12-01' = {
  name: hostingPlanName
  location: location
  sku: {
    name: 'Y1'
    tier: 'Dynamic'
  }
  kind: 'functionapp'
}

/*
|--------------------------------------------------------------------------
| Function App
|--------------------------------------------------------------------------
*/
resource functionApp 'Microsoft.Web/sites@2025-03-01' = {
  name: functionAppName
  location: location
  kind: 'functionapp'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: hostingPlan.id
    httpsOnly: true
    siteConfig: {
      netFrameworkVersion: 'v8.0'
      appSettings: [
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${runtimeStorage.name};EndpointSuffix=${environment().suffixes.storage};AccountKey=${runtimeStorage.listKeys().keys[0].value}'
        }
        {
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: functionsWorkerRuntime
        }
        {
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: functionsExtensionVersion
        }
        {
          name: 'ImagesStorage__queueServiceUri'
          value: 'https://${queueStorage.name}.queue.${environment().suffixes.storage}'
        }
      ]
    }
  }
}

/*
|--------------------------------------------------------------------------
| RBAC - Queue Storage Data Contributor
|--------------------------------------------------------------------------
*/
resource queueStorageRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(queueStorage.id, functionApp.id, 'Storage Queue Data Contributor')
  scope: queueStorage

  properties: {
    principalId: functionApp.identity.principalId
    principalType: 'ServicePrincipal'

    roleDefinitionId: subscriptionResourceId(
      'Microsoft.Authorization/roleDefinitions',
      '974c5e8b-45b9-4653-ba55-5f855dd0fb88'
    )
  }
}
