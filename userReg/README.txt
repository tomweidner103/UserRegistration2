dotnet new webapi

Models
|__AuthenticationContext.cs

Data Source=192.168.1.133, 1401\\Database=userDB;user=SA;password=<myPassword>; for msssql

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design

dotnet ef migrations add <name>
dotnet ef database update

Port 5000 is for postman stuff
Port 5001 is for localhost browser stuff

dotnet add package Microsoft.AspNetCore.Cors ( cross platform reference )

if certificate is failing to produce a response, then you must run dotnet dev-certs https --trust in the command line to allow https certificates
