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
* Entity Product has a related entity, the Category, with navigation property.
* **Bootstrap 5** is used for styling the web application.
* Authentication is required to use Products and Categories.
* **ASP.NET Identity** is used to create authentication by using the scaffolding feature: the sel-generations works very well with no initial users created.

## Documentation References

* [.NET CLI (`dotnet` command)](https://docs.microsoft.com/en-us/dotnet//core/tools)
* [ASP.NET Core MVC 7](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0)
* [LibMan CLI](https://learn.microsoft.com/en-us/aspnet/core/client-side/libman/libman-cli?view=aspnetcore-6.0)
* **User Interface**
  * [Tag Helpers](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-7.0)
  * [Razor Syntax](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=apnetcore-7.0)
  * [Validation and Data Annotations](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation)
* **FluentValidation**
  * [General Documentation](https://docs.fluentvalidation.net/en/latest/)
* **Data / Entity Framework (EF) Core**
  * [Entity Framework](https://docs.microsoft.com/en-us/ef/core)
  * [Database Providers](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)
  * [Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations)
  * [Relationships](https://docs.microsoft.com/en-us/ef/core/modeling/relationships)
* **Identity**
  * [General Documentations](https://docs.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-8.0)
  * [Scaffolding Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity)
  
  



