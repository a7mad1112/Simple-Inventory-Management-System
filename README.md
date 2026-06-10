# Simple Inventory Management System

A console-based inventory management system built with C#.

## Features

- Add a product
- View all products
- Edit a product
- Delete a product
- Search for a product

Each product contains:

- Name
- Price
- Quantity

## Architecture

The project is organized into separate layers:

- Models
- Repositories
- Services
- UI

The application uses:

- Dependency Injection
- Repository Pattern
- Constructor Injection

## Note

For a simple console CRUD application, applying the Repository Pattern and Dependency Injection may be more architecture than the project strictly requires. These patterns were intentionally used for learning and practice purposes to improve understanding of:

- SOLID principles
- Separation of concerns
- Dependency management
- Maintainable application design

## Running the Application

```bash
dotnet run
```

## Technologies

- C#
- Microsoft.Extensions.DependencyInjection
- Git & GitHub