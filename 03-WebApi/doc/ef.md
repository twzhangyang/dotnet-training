## Create the database
- install dotnet-ef
```
dotnet tool install --global dotnet-ef
```
- update if it's already installed
```
dotnet tool update --global dotnet-ef
```
- add package
```
Microsoft.EntityFrameworkCore.Design
```
- add migration
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

