# Lycevm Help Desk — EF Core Database-First MVC

An ASP.NET Core MVC Help Desk application built against the supplied `lycevm.db` SQLite database using Entity Framework Core Database-First principles.

## Requirements

- ASP.NET Core MVC
- .NET 8
- Entity Framework Core 8
- SQLite
- Razor Views
- LINQ
- Built-in Dependency Injection

## Important Database Rules

`lycevm.db` is the source of truth. The supplied database is used as-is.

This project does **not**:

- scaffold the database;
- generate entities using EF scaffolding;
- create another database;
- use migrations to create or modify the database;
- seed data;
- modify or remove existing database data.

The C# entity classes and relationship mappings were manually created from inspection of the supplied SQLite schema.

## NuGet Package

- `Microsoft.EntityFrameworkCore.Sqlite` 8.0.18

## Database Location

Place `lycevm.db` in the project root. The configured connection string is:

```text
Data Source=lycevm.db
```

## How to Run

1. Install the .NET 8 SDK.
2. Clone the GitHub repository.
3. Open a terminal in the project folder.
4. Restore packages:

```bash
dotnet restore
```

5. Build:

```bash
dotnet build
```

6. Run:

```bash
dotnet run
```

7. Open the URL shown by ASP.NET Core.

## Main Features

- Departments
- Employees
- Teams
- Customers
- Tickets
- Ticket details with assignments, comments, tags and attachments
- Employee workload
- Department workload
- Unassigned tickets
- Multiple-assignee tickets
- Primary assignee
- Category hierarchy

## GitHub Workflow

`main` is the permanent integration branch. Feature work must not be pushed directly to `main`.

Create a feature branch, commit focused changes, push the branch, open a Pull Request, have another group member review and approve it, and then merge the Pull Request.

The assignment requires at least 10 Pull Requests per member. PRs should be meaningful and should not be bulk or fake activity.

See `BRANCH_PLAN.md` for the branch organization derived from the assignment requirements. The referenced Proposed Branch document was not supplied.

## Database Investigation

See `DATABASE.md` for the inspected tables, columns, keys, foreign keys, nullable fields and relationship summary.

## Opening the project with Visual Studio

Open `LycevmHelpDesk.sln` from the project root. The solution contains the `LycevmHelpDesk` ASP.NET Core MVC project.

Use the Visual Studio Run button (or Ctrl+F5) to launch the application. Do not run the generated executable directly from `bin\\Debug\\net8.0`; run the project/solution so the project directory is used as the content root and `wwwroot` and `lycevm.db` are found correctly.
