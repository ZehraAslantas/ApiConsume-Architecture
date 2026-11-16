# ✅ TodoApp

A task management web application built with **ASP.NET Core Razor Pages** (.NET 9). It supports full CRUD operations, search and filtering, validation with FluentValidation, and also displays news fetched from an external **News Web API**.

## 🚀 Features

- **Full CRUD:** Create, list, edit and delete tasks.
- **Task details:** Title, description, priority (Low / Medium / High), due date and completion status.
- **Search, filter and sort:** Search by title and description, filter by priority and status (done / pending), and sort by due date.
- **Validation with FluentValidation:** Rules such as a required title, length limits and a due date that cannot be in the past. Basic rules are also applied on the client side.
- **Swappable data layer:** The `ITodoStore` interface has two implementations: `InMemoryTodoStore` (used in Development) and `EfTodoStore` (SQL Server via EF Core, used in Production).
- **EF Core configuration:** Fluent API configuration, indexes on due date, priority and status, and seed data.
- **News integration:** The `/News` page lists articles from the News API and shows their details, using a **Typed HttpClient** (`NewsClient`) and a `NewsArticleDto`.
- **Resilient API calls:** If the News API is unreachable, errors are caught and logged, and the news page shows a friendly message instead of crashing.
- **Reusable form:** A Razor partial (`_TodoForm`) shared by the create and edit pages.
- **User feedback:** Success and error messages with `TempData` after each action.
- **Responsive UI:** Built with Bootstrap 5.

## 🛠️ Tech Stack

- .NET 9, C#
- ASP.NET Core Razor Pages
- Entity Framework Core (SQL Server)
- FluentValidation
- Bootstrap 5

## ▶️ Running

**Prerequisites:** .NET 9 SDK, SQL Server LocalDB

```bash
dotnet run --project TodoApp --launch-profile https
```

Then open **https://localhost:7226**.

> The news page requires the **News API** to be running at `https://localhost:7080/`. This address can be changed in `appsettings.json` (`NewsApi:BaseUrl`).

## 📁 Project Structure

```
TodoApp/
├── Models/               # Todo, ToDoPriority
├── Pages/
│   ├── Todos/            # Index, Create, Edit, Delete, _TodoForm
│   └── News/             # Index, Details
├── Services/
│   ├── ITodoStore.cs
│   ├── InMemoryTodoStore.cs
│   ├── EfTodoStore.cs
│   ├── INewsClient.cs
│   └── NewsApi/          # NewsClient, NewsArticleDto
├── Validators/           # TodoValidator
├── Repositories/         # TodoDbContext, Config/
└── Program.cs
```
