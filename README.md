# CodeCraft - Clean Architecture CRUD API

A showcase .NET API project demonstrating modern software architecture patterns and best practices through a comprehensive CRUD operations implementation.

## 🎯 Project Overview

CodeCraft is a .NET API built to demonstrate proficiency in clean architecture principles, advanced design patterns, and modern development practices. The project implements a complete product management system with full CRUD operations while maintaining high code quality and architectural integrity.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with a clear separation of concerns across multiple layers:

```
CodeCraft/
├── Domain/                 # Core business logic and entities
├── Application/           # Use cases and business rules
├── Infrastructure/        # External concerns (database, services)
├── Persistence/          # Data access layer
├── Query/                # Read operations and queries
└── Presentation/         # API controllers and endpoints
```

### Layer Responsibilities

- **Domain Layer**: Contains business entities, domain services, and core business rules
- **Application Layer**: Orchestrates business workflows and implements use cases via MediatR
- **Infrastructure Layer**: Handles external dependencies and cross-cutting concerns
- **Persistence Layer**: Manages data persistence using Entity Framework Core
- **Query Layer**: Optimized read operations using Dapper for performance
- **Presentation Layer**: REST API endpoints and request/response handling

## 🚀 Key Technologies & Patterns

### Core Technologies
- **.NET 8** - Latest framework features and performance improvements
- **ASP.NET Core Web API** - RESTful API development
- **Entity Framework Core** - Write operations and data modeling
- **Dapper** - High-performance read operations
- **PostgreSQL** - Production-grade relational database

### Design Patterns & Libraries
- **MediatR Pattern** - Decoupled request/response handling
- **CQRS (Command Query Responsibility Segregation)** - Separate read and write operations
- **FluentResults** - Elegant error handling and result patterns
- **Clean Architecture** - Dependency inversion and separation of concerns

## 📊 Database Strategy

The project implements a hybrid data access approach:

- **Entity Framework Core**: Handles all write operations (Create, Update, Delete) with full change tracking and domain model mapping
- **Dapper**: Powers read operations (List, Details) for optimal query performance and reduced overhead

This dual approach provides the benefits of EF Core's rich modeling capabilities for writes while leveraging Dapper's speed for read-heavy operations.

## 🔌 API Endpoints

### Products API
Base URL: `/api/products`

| Method | Endpoint | Description | Response |
|--------|----------|-------------|----------|
| `GET` | `/products` | Retrieve all products | List of products |
| `GET` | `/products/{id}` | Get product by ID | Single product details |
| `POST` | `/products` | Create new product | Created product |
| `PUT` | `/products/{id}` | Update existing product | Updated product |
| `DELETE` | `/products/{id}` | Delete product | Success confirmation |

### Example Requests

#### Get All Products
```http
GET /products
```

#### Get Product by ID
```http
GET /products/{id:guid}
```

#### Create Product
```http
POST /products
Content-Type: application/json

{
  "name": "Laptop Pro",
  "description": "High-performance laptop for professionals"
}
```

#### Update Product
```http
PUT /products/{id:guid}
Content-Type: application/json

{
  "name": "Laptop Pro Max",
  "description": "Ultimate high-performance laptop"
}
```

#### Delete Product
```http
DELETE /products/{id:guid}
```

## 🛠️ Technical Implementation Highlights

### MediatR Integration
- **Commands**: Handle write operations (Create, Update, Delete)
- **Queries**: Manage read operations (List, Get by ID)
- **Handlers**: Encapsulate business logic for each operation

### FluentResults Pattern
```csharp
public class Result<T>
{
    public bool IsSuccess { get; }
    public T Value { get; }
    public List<string> Errors { get; }
}
```

### Domain-Driven Design
- Rich domain entities with business logic
- Domain services for complex business rules
- Value objects for data integrity
- Repository pattern for data access abstraction

## 📁 Project Structure

```
src/
├── CodeCraft.Domain/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Services/
│   └── Repositories/
├── CodeCraft.Application/
│   ├── Commands/
│   ├── Queries/
│   ├── Handlers/
│   └── Behaviors/
├── CodeCraft.Infrastructure/
│   ├── Services/
│   └── Configuration/
├── CodeCraft.Persistence/
│   ├── Context/
│   ├── Repositories/
│   └── Configurations/
├── CodeCraft.Query/
│   ├── Handlers/
│   └── Models/
└── CodeCraft.Presentation/
    ├── Controllers/
    └── Extensions/
```

## ⚙️ Getting Started

### Prerequisites
- .NET 8 SDK
- PostgreSQL 12+
- Your favorite IDE (Visual Studio, VS Code, Rider)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/codecraft.git
   cd codecraft
   ```

2. **Configure database connection**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": ""Host=localhost;Port=5432;Username=postgres;Password=;Database=CodeCraftDB;Include Error Detail=true"
     }
   }
   ```

3. **Run database migrations**
   ```bash
   dotnet ef database update
   ```

4. **Start the application**
   ```bash
   dotnet run --project src/CodeCraft.Presentation
   ```

5. **Access the API**
   - API: `https://localhost:7025`
   - Swagger UI: `https://localhost:7025/swagger`

## 🎯 Project Goals

This project serves as a comprehensive demonstration of:

- **Clean Architecture Implementation** - Proper layer separation and dependency management
- **Modern .NET Development** - Latest framework features and best practices
- **Advanced Design Patterns** - MediatR, CQRS, Repository, and Result patterns
- **Database Optimization** - Strategic use of EF Core and Dapper
- **API Design** - RESTful principles and proper HTTP semantics
- **Error Handling** - Robust error management with FluentResults
- **Code Organization** - Maintainable and scalable project structure

## 📝 Notes

This project prioritizes architectural clarity and code quality over extensive feature sets. The implementation showcases professional development practices and modern .NET capabilities through a focused, well-structured codebase.

---

**CodeCraft** - Crafting clean, maintainable, and scalable .NET applications.
