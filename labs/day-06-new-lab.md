

dotnet new mvc --auth SingleOrg --client-id 2a3dbf58-74c2-4b61-829c-5770ce18d4e8 --tenant-id 7f1ff4a9-8a03-49e2-92d7-d39b69dbcea6 --domain alexdam1989gmail.onmicrosoft.com --name AuthDemo

dotnet dev-certs https --trust

https://localhost:7294/signin-oidc

https://localhost:7294/signout-oidc
