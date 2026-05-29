az deployment group what-if `
  --resource-group myResourceGroup `
  --template-file main.bicep `
  --parameters main.bicepparam `
  --exclude-change-types Ignore NoChange

#az bicep lint --file main.bicep