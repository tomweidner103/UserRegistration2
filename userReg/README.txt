dotnet new webapi

Models
|__AuthenticationContext.cs

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet ef migrations add <name>
dotnet ef database update

Port 5000 is for postman stuff
Port 5001 is for localhost browser stuff

dotnet add package Microsoft.AspNetCore.Cors ( cross platforma reference )