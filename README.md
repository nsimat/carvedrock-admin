# Carved Rock Admin

## Prerequisites

* Install the [.NET SDK](https://dotnet.microsoft.com/en-us/download).
* Have installed the following IDEs:
  * the [VS Code](https://code.visualstudio.com) including the [C# language extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
  * the [JetBrains Rider](https://www.jetbrains.com/rider/)
* Trust the dotnet dev https certificate: `dotnet dev-certs http -t`
* Have installed the Entity Framework Core CLI: ` dotnet tool install --global dotnet-ef`

## The App Features

This project is about building a web application for a fictional company named **Carved Rock** for its employee to use as an administration tool to maintain the products it sells and their categories they belong to. For that purpose, many technologies are used:

* The primary technology used in our project is **ASP.NET Core MVC 7**.
* **Entity Framework (EF) Core 7** is used with SQLite for database.
* Basic CRUD operations are supported on Products.
* Repository classes are used with **Dependency Injection (DI)** for testability support.
* **Bootstrap 5** is used for styling the web application.

## Documentation References

* [.NET CLI (`dotnet` command)](https://docs.microsoft.com/en-us/dotnet//core/tools)
* [ASP.NET Core MVC 7](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0



