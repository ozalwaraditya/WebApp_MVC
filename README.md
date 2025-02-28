# ASP.NET MVC Project

## Overview

This project is an ASP.NET MVC application developed using C# and the .NET Framework. The application follows best practices, including the Repository Pattern and N-tier architecture, and integrates Entity Framework with Code-First Migrations.

## Key Concepts Learned

While developing this application, the following key concepts were implemented and explored:

- **C# and .NET Framework**
- **Object-Oriented Programming (OOP)**
- **Repository Pattern for Data Access**
- **N-tier Architecture Implementation**
- **Entity Framework with Code-First Migrations**
- **Sessions in ASP.NET Core**
- **Custom Tag Helpers in ASP.NET Core**
- **View Components and Partial Views in ASP.NET Core**
- **Authentication and Authorization in ASP.NET Core**
- **Role Management in ASP.NET Core Identity**
- **TempData, ViewBag, and ViewData in ASP.NET Core**
- **Automatic Database Seeding with Migrations**

## Technologies Used

- ASP.NET MVC
- C#
- .NET Framework / .NET Core
- Entity Framework Core
- SQL Server
- Identity Management

## Installation and Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/ozalwaraditya/WebApp_MVC
   cd WebApp_MVC
   ```
2. Install dependencies and restore NuGet packages:
   ```sh
   dotnet restore
   ```
3. Apply database migrations:
   ```sh
   dotnet ef database update
   ```
4. Run the application:
   ```sh
   dotnet run
   ```

## Authentication and Authorization

- Implemented ASP.NET Core Identity for user authentication.
- Role-based access control for managing permissions.

## Database Seeding

- Automatic database seeding is configured in the `OnModelCreating` method.
- Initial admin roles and users are seeded on application startup.

## Contribution

Contributions are welcome! Please submit a pull request or open an issue for discussion.

## License

This project is licensed under the MIT License.

## Contact

For any questions or issues, feel free to reach out.

Email : adityaozalwar14\@gmail.com

