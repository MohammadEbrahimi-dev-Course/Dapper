# Dapper with ASP.NET Core 8

This repository contains code examples and implementations from the **Dapper in ASP.NET Core** course. The course demonstrates how to integrate Dapper, a lightweight ORM, into .NET Core 8 applications to interact with SQL Server databases efficiently.

---

## 📚 Course Link

You can find the course here:  
[**آموزش استفاده از Dapper در AspNet Core**](https://toplearn.com/courses/web/%D8%A2%D9%85%D9%88%D8%B2%D8%B4-%D8%A7%D8%B3%D8%AA%D9%81%D8%A7%D8%AF%D9%87-%D8%A7%D8%B2-Dapper-%D8%AF%D8%B1-AspNet-Core)

---

## ⚙️ Prerequisites

- **.NET Core**: 8.0  
- **Dapper**: 2.1.35  
- **SQL Server Management Studio (SSMS)**: 18.12.2

---

## 🗂️ Database Setup

### Step 1: Create the Database
Run the following SQL commands in SQL Server Management Studio:

```sql
CREATE DATABASE [Dapper]

USE [Dapper]

CREATE TABLE [dbo].[Product] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
     [float] NULL,
    [CreateDate] [datetime] NULL
)

INSERT INTO [dbo].[Product]
    (Name, Cost, CreateDate) 
    VALUES 
    ('Dapper Test', 20, '2024-2-2')


```
---

##🚀 Project Setup

###Step 1: Create ASP.NET Core API Project
- Use the .NET CLI or Visual Studio to create a new ASP.NET Core Web API project targeting .NET Core 8.

###Step 2: Add the Dapper Package
Add the Dapper NuGet package to your project:
``` bash
dotnet add package Dapper --version 2.1.35
```

---
## 📁 Project Structure

The project follows a modular structure with the following key components:

### 🗂️ Models
Located in the `Models` folder, the `Product` class maps to the `Product` table in the database:

```csharp
// Models/Product.cs

public class Product
{
    public int Id { get; set; }         // Primary key of the Product table
    public string Name { get; set; }    // Name of the product
    public float? Cost { get; set; }    // Cost of the product
    public DateTime? CreateDate { get; set; } // Date the product was created
}
```

### 🗂️ Interfaces

#### `ICommandText`
The `ICommandText` interface provides SQL commands for Dapper operations:

```csharp
// Interfaces/ICommandText.cs

public interface ICommandText
{
    string GetProducts { get; }      // SQL command to retrieve all products
    string GetProductById { get; }   // SQL command to retrieve a product by ID
    string AddProduct { get; }       // SQL command to add a new product
    string UpdateProduct { get; }    // SQL command to update an existing product
    string RemoveProduct { get; }    // SQL command to remove a product by ID
}

```

### 🗂️ IProductRepository Implementation

The `IProductRepository` interface is implemented to interact with the database using Dapper.

```csharp
// Repositories/IProductRepository.cs

public interface IProductRepository
{
    List<Product> GetAllProduct();
    Product GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void RemoveProduct(int id);
}
```

##Repository Implementation
You will implement the `IProductRepository` interface to interact with the database using Dapper.

---

## 📡 API Endpoints

Here are the endpoints exposed by the application:

### GET /api/products
- **Description**: Retrieve all products.
- **Method**: `GET`

### GET /api/products/{id}
- **Description**: Retrieve a single product by ID.
- **Method**: `GET`

### POST /api/products
- **Description**: Add a new product.
- **Method**: `POST`

### PUT /api/products/{id}
- **Description**: Update an existing product.
- **Method**: `PUT`

### DELETE /api/products/{id}
- **Description**: Remove a product by ID.
- **Method**: `DELETE`

---

## ⚙️ Configuration

### Connection String
Add the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=Dapper;Trusted_Connection=True;"
}
```

## ⚙️ Configuration

### Connection String
Add the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=Dapper;Trusted_Connection=True;"
  }
}
```
### 🔧 Register Services

In the `Program.cs` file, register your services and configure the database connection:

```csharp
// Program.cs

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICommandText, CommandText>();
```
---
## ▶️ How to Run

1. Clone this repository:

```bash
git clone [https://github.com/MohammadEbrahimi-dev-Course/Dapper.git](https://github.com/MohammadEbrahimi-dev-Course/Dapper.git)
```
2. Set up the database using the provided SQL script.

3. Configure the connection string in `appsettings.json`:
4. 
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=Dapper;Trusted_Connection=True;"
}
```

4.Build and run the project using the following command:

``` bash
dotnet run
```

5.Use tools like Postman or Swagger to test the API endpoints.

## ✍️ Author

This repository is created as part of the **Dapper in ASP.NET Core** course on [TopLearn](https://toplearn.com).

Happy coding! 🚀

