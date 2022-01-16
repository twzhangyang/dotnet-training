## .NET API
### nullable

```
<Nullable>enable</Nullable>
```

### Logging
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0#third-party-logging-providers
### NLog
1. Add dependency in csproj manually or using NuGet
```
<ItemGroup>
  <PackageReference Include="NLog.Web.AspNetCore" Version="4.*" />
  <PackageReference Include="NLog" Version="4.*" />
</ItemGroup>
```
2. Create a nlog.config file.
3. Update program.cs
  

### Handle errors in ASP.NET Core
- Error handler middleware
- Use exceptions filter to modify the response
- Logging unhandled exception
