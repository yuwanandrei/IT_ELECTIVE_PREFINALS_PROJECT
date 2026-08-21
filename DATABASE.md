# Database Investigation

Database: `lycevm.db` (supplied SQLite database).

## Tables

### `Customers`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `CompanyName` | `TEXT` | No | `None` | 0 |
| `ContactName` | `TEXT` | No | `None` | 0 |
| `Email` | `TEXT` | No | `None` | 0 |
| `Phone` | `TEXT` | Yes | `None` | 0 |
| `CreatedAt` | `TEXT` | No | `None` | 0 |
| `IsActive` | `INTEGER` | No | `1` | 0 |

**Foreign keys:** None.

### `Departments`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `Name` | `TEXT` | No | `None` | 0 |
| `Description` | `TEXT` | Yes | `None` | 0 |
| `IsActive` | `INTEGER` | No | `1` | 0 |

**Foreign keys:** None.

### `Employees`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `DepartmentId` | `INTEGER` | No | `None` | 0 |
| `FirstName` | `TEXT` | No | `None` | 0 |
| `LastName` | `TEXT` | No | `None` | 0 |
| `Email` | `TEXT` | No | `None` | 0 |
| `JobTitle` | `TEXT` | No | `None` | 0 |
| `HireDate` | `TEXT` | No | `None` | 0 |
| `IsActive` | `INTEGER` | No | `1` | 0 |

**Foreign keys:**
- `DepartmentId` → `Departments.Id` (update: `NO ACTION`, delete: `NO ACTION`)

### `Tags`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `Name` | `TEXT` | No | `None` | 0 |

**Foreign keys:** None.

### `TeamMembers`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `TeamId` | `INTEGER` | No | `None` | 1 |
| `EmployeeId` | `INTEGER` | No | `None` | 2 |
| `JoinedAt` | `TEXT` | No | `None` | 0 |

**Foreign keys:**
- `EmployeeId` → `Employees.Id` (update: `NO ACTION`, delete: `NO ACTION`)
- `TeamId` → `Teams.Id` (update: `NO ACTION`, delete: `NO ACTION`)

### `Teams`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `DepartmentId` | `INTEGER` | No | `None` | 0 |
| `Name` | `TEXT` | No | `None` | 0 |
| `Description` | `TEXT` | Yes | `None` | 0 |

**Foreign keys:**
- `DepartmentId` → `Departments.Id` (update: `NO ACTION`, delete: `NO ACTION`)

### `TicketAssignments`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `TicketId` | `INTEGER` | No | `None` | 1 |
| `EmployeeId` | `INTEGER` | No | `None` | 2 |
| `AssignedAt` | `TEXT` | No | `None` | 0 |
| `UnassignedAt` | `TEXT` | Yes | `None` | 0 |
| `IsPrimary` | `INTEGER` | No | `0` | 0 |

**Foreign keys:**
- `EmployeeId` → `Employees.Id` (update: `NO ACTION`, delete: `NO ACTION`)
- `TicketId` → `Tickets.Id` (update: `NO ACTION`, delete: `NO ACTION`)

### `TicketAttachments`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `TicketId` | `INTEGER` | No | `None` | 0 |
| `FileName` | `TEXT` | No | `None` | 0 |
| `ContentType` | `TEXT` | No | `None` | 0 |
| `FileSize` | `INTEGER` | No | `None` | 0 |
| `UploadedAt` | `TEXT` | No | `None` | 0 |

**Foreign keys:**
- `TicketId` → `Tickets.Id` (update: `NO ACTION`, delete: `NO ACTION`)

### `TicketCategories`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `ParentCategoryId` | `INTEGER` | Yes | `None` | 0 |
| `Name` | `TEXT` | No | `None` | 0 |
| `Description` | `TEXT` | Yes | `None` | 0 |

**Foreign keys:**
- `ParentCategoryId` → `TicketCategories.Id` (update: `NO ACTION`, delete: `NO ACTION`)

### `TicketComments`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `TicketId` | `INTEGER` | No | `None` | 0 |
| `EmployeeId` | `INTEGER` | Yes | `None` | 0 |
| `Comment` | `TEXT` | No | `None` | 0 |
| `CreatedAt` | `TEXT` | No | `None` | 0 |
| `IsInternal` | `INTEGER` | No | `0` | 0 |

**Foreign keys:**
- `EmployeeId` → `Employees.Id` (update: `NO ACTION`, delete: `NO ACTION`)
- `TicketId` → `Tickets.Id` (update: `NO ACTION`, delete: `NO ACTION`)

### `TicketPriorities`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `Name` | `TEXT` | No | `None` | 0 |
| `SortOrder` | `INTEGER` | No | `None` | 0 |
| `ResponseHours` | `INTEGER` | No | `None` | 0 |

**Foreign keys:** None.

### `TicketStatuses`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `Name` | `TEXT` | No | `None` | 0 |
| `IsClosed` | `INTEGER` | No | `0` | 0 |

**Foreign keys:** None.

### `TicketTags`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `TicketId` | `INTEGER` | No | `None` | 1 |
| `TagId` | `INTEGER` | No | `None` | 2 |

**Foreign keys:**
- `TagId` → `Tags.Id` (update: `NO ACTION`, delete: `NO ACTION`)
- `TicketId` → `Tickets.Id` (update: `NO ACTION`, delete: `NO ACTION`)

### `Tickets`

| Column | SQLite Type | Nullable | Default | Primary Key Position |
|---|---|---|---|---:|
| `Id` | `INTEGER` | Yes | `None` | 1 |
| `CustomerId` | `INTEGER` | No | `None` | 0 |
| `CategoryId` | `INTEGER` | No | `None` | 0 |
| `PriorityId` | `INTEGER` | No | `None` | 0 |
| `StatusId` | `INTEGER` | No | `None` | 0 |
| `Subject` | `TEXT` | No | `None` | 0 |
| `Description` | `TEXT` | No | `None` | 0 |
| `CreatedAt` | `TEXT` | No | `None` | 0 |
| `UpdatedAt` | `TEXT` | No | `None` | 0 |
| `DueAt` | `TEXT` | Yes | `None` | 0 |
| `ResolvedAt` | `TEXT` | Yes | `None` | 0 |
| `ClosedAt` | `TEXT` | Yes | `None` | 0 |

**Foreign keys:**
- `StatusId` → `TicketStatuses.Id` (update: `NO ACTION`, delete: `NO ACTION`)
- `PriorityId` → `TicketPriorities.Id` (update: `NO ACTION`, delete: `NO ACTION`)
- `CategoryId` → `TicketCategories.Id` (update: `NO ACTION`, delete: `NO ACTION`)
- `CustomerId` → `Customers.Id` (update: `NO ACTION`, delete: `NO ACTION`)

## Relationship Summary

- **One-to-many:** Departments → Employees; Departments → Teams; Customers → Tickets; TicketCategories → Tickets; TicketPriorities → Tickets; TicketStatuses → Tickets; Tickets → TicketComments; Tickets → TicketAttachments; Tickets → TicketAssignments; Employees → TicketAssignments; Employees → TicketComments; Teams → TeamMembers; Employees → TeamMembers; Tags → TicketTags.
- **Many-to-many:** Teams ↔ Employees through `TeamMembers`; Tickets ↔ Employees through `TicketAssignments`; Tickets ↔ Tags through `TicketTags`.
- **Self-referencing:** `TicketCategories.ParentCategoryId` references `TicketCategories.Id`.
- **Optional relationships:** `TicketCategories.ParentCategoryId`, `TicketComments.EmployeeId`, `Tickets.DueAt`, `Tickets.ResolvedAt`, `Tickets.ClosedAt`, `Customers.Phone`, `Departments.Description`, and `Teams.Description` are nullable.
- **Composite primary keys:** `TeamMembers(TeamId, EmployeeId)`, `TicketAssignments(TicketId, EmployeeId)`, and `TicketTags(TicketId, TagId).`

## Row Counts at Inspection Time

| Table | Rows |
|---|---:|
| `Customers` | 20 |
| `Departments` | 7 |
| `Employees` | 17 |
| `Tags` | 20 |
| `TeamMembers` | 17 |
| `Teams` | 8 |
| `TicketAssignments` | 42 |
| `TicketAttachments` | 8 |
| `TicketCategories` | 17 |
| `TicketComments` | 23 |
| `TicketPriorities` | 4 |
| `TicketStatuses` | 5 |
| `TicketTags` | 46 |
| `Tickets` | 30 |