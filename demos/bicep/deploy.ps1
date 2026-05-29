az deployment group create `
  --resource-group myResourceGroup `
  --template-file main.bicep `
  --parameters main.bicepparam `
  --output table