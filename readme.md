# ProductsWebAPI

## Overview
ProductsWebAPI is a .NET 8 web API project that manages product information. It uses the repository pattern for data access and includes utility functions for generating unique IDs.

## Getting Started

### 1. Adding Default Connection String

To set up the connection string for the database, follow these steps:

1. Open the `appsettings.json` file in the root of the project.
2. Add the following JSON snippet to the `ConnectionStrings` section:

    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;"
        }
    }


Replace `your_server_name`, `your_database_name`, `your_username`, and `your_password` with your actual database server details.

### 2. Updating Migrations Using EF Core

To update the database schema using Entity Framework Core migrations, follow these steps:

1. Open Package Manager console.
2. Run the following command to update the Database schema to the new DB Instance new migration:

    Update-Database


### 3. ID Generation Function

The `Utilities.cs` file contains a function `GenerateIdUsingSeedHashing` that generates a unique ID based on the product name and product type. Here's how it works:

- The function concatenates the product name and product type, normalizes them to lowercase, and trims any whitespace.
- It then applies a SHA-256 hash to the concatenated string.
- The first 8 characters of the hash are extracted and converted to a numeric value.
- The numeric value is then reduced to a 6-digit number using modulo 1000000.
- If the resulting number is less than 100000, it is adjusted to ensure it is always a 6-digit number.

### 4. Code Design Pattern

The project uses the **Repository Pattern** for data access. This pattern provides a way to encapsulate the data access logic and separate it from the business logic. It helps in achieving a clean architecture and makes the code more maintainable and testable.

### 5. Developer's Best Practices

- **Separation of Concerns**: Keep different parts of the application separate to make the code more maintainable and testable.
- **Dependency Injection**: Use dependency injection to manage dependencies and improve testability.
- **Error Handling**: Implement proper error handling to ensure the application can gracefully handle unexpected situations.
- **Logging**: Use logging to track the application's behavior and diagnose issues.
- **Code Reviews**: Regularly review code to ensure it meets quality standards and follows best practices.
- **Unit Testing**: Write unit tests to verify the functionality of the code and catch bugs early.
- **Consistent Naming Conventions**: Use consistent naming conventions to make the code more readable and understandable.
- **Documentation**: Document the code and provide clear instructions for setting up and using the application.



