# Branch Plan

The assignment references a "Proposed Branch per User Story" document, but no such document was supplied. This branch plan is therefore derived directly from the official assignment requirements.

## Permanent Branch
- `main` — stable, reviewed integration branch.

## Feature Branches
1. `feature/database-investigation` — inspect and document `lycevm.db`.
2. `feature/ef-core-model` — manually create entity classes and mappings.
3. `feature/db-context` — create and configure `HelpDeskContext`.
4. `feature/dependency-injection` — register EF Core through DI.
5. `feature/departments` — Departments page.
6. `feature/employees` — Employees page.
7. `feature/teams` — Teams page.
8. `feature/customers` — Customers page.
9. `feature/tickets` — Tickets listing.
10. `feature/ticket-details` — detailed ticket page with related data.
11. `feature/workload-queries` — Employee and Department workload queries.
12. `feature/ticket-queries` — Unassigned, Multiple-Assignee, Primary Assignee and Category Hierarchy queries.
13. `feature/documentation` — README and database documentation.

## Paired-Programming Workflow

The three group members should work in pairs for each development session. The developer pair should agree on the change, one member can drive while the other reviews, and the resulting work must be pushed to a feature branch. A Pull Request must then be opened into `main` and reviewed/approved by another group member before merging.

Each member must independently create at least 10 meaningful Pull Requests. Do not create fake PRs or meaningless branches just to meet the number.
