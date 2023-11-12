# Task Service API
This project was created to demonstrate a REST API for a Task Service in which new tasks lists can be created, under 
which tasks can be generated and managed. For ease-of-use with this private Git repo, the appsettings files have been 
committed to source control for easy cloning, which would not be the case in a production environment. 

## Technologies
- ASP.NET Core 8: The latest preview build and code styles for ASP.Net Core.
- Entity Framework Core 8: The latest preview build and code styles for Entity Framework Core.
- MediatR/CQRS Pattern: A clean framework for handling commands and queries.
- AutoMapper: A clean framework for mapping objects to DTOs.
- FluentValidation: A clean framework for validating commands and queries.
- NSwag: Automatic API documentation generation for Swagger/OpenAPI.
- MSSQL: The database of choice for this project.

## Build

Run `dotnet build -tl` to build the solution.

## Run

1. Navigate to https://localhost:5001 to view the Swagger OpenAPI specifications doc that will expose all the endpoints 
available. 
2. Utilizing the bundled [Insomnia workspace](./Insomnia-Repo.json) will allow you to test the API endpoints.
3. Alternatively, you can use the Swagger UI to test the API endpoints.
4. The login and password for the base user can be found in the Private Environment inside Insomnia, or in the seed database method. 