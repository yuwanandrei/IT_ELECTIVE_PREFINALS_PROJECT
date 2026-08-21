using LycevmHelpDesk.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LycevmHelpDesk.Controllers;

public class QueriesController : Controller
{
    private readonly HelpDeskContext _context;
    public QueriesController(HelpDeskContext context) => _context = context;

    public async Task<IActionResult> EmployeeWorkload()
    {
        var rows = await _context.Employees.Where(e => e.IsActive)
            .Select(e => new EmployeeWorkloadRow
            {
                Employee = e.FirstName + " " + e.LastName,
                Department = e.Department.Name,
                UnresolvedTicketCount = e.TicketAssignments.Count(a => a.UnassignedAt == null && !a.Ticket.Status.IsClosed)
            }).OrderBy(r => r.Department).ThenBy(r => r.Employee).ToListAsync();
        return View(rows);
    }

    public async Task<IActionResult> DepartmentWorkload()
    {
        var rows = await _context.Departments
            .Select(d => new DepartmentWorkloadRow
            {
                Department = d.Name,
                EmployeeCount = d.Employees.Count,
                UnresolvedTicketCount = d.Employees.SelectMany(e => e.TicketAssignments)
                    .Count(a => a.UnassignedAt == null && !a.Ticket.Status.IsClosed)
            }).OrderBy(r => r.Department).ToListAsync();
        return View(rows);
    }

    public async Task<IActionResult> UnassignedTickets()
    {
        var rows = await _context.Tickets
            .Where(t => !t.Assignments.Any(a => a.UnassignedAt == null))
            .Select(t => new UnassignedTicketRow
            {
                TicketId = t.Id, Subject = t.Subject, Customer = t.Customer.CompanyName,
                Priority = t.Priority.Name, Status = t.Status.Name, CreatedAt = t.CreatedAt
            }).OrderByDescending(r => r.CreatedAt).ToListAsync();
        return View(rows);
    }

    public async Task<IActionResult> MultipleAssigneeTickets()
    {
        var tickets = await _context.Tickets
            .Where(t => t.Assignments.Count(a => a.UnassignedAt == null) > 1)
            .Include(t => t.Assignments).ThenInclude(a => a.Employee)
            .OrderBy(t => t.Id).ToListAsync();

        var rows = tickets.Select(t => new MultipleAssigneeRow
        {
            TicketId = t.Id,
            Subject = t.Subject,
            NumberOfActiveAssignees = t.Assignments.Count(a => a.UnassignedAt == null),
            Assignees = string.Join(", ", t.Assignments.Where(a => a.UnassignedAt == null)
                .Select(a => a.Employee.FirstName + " " + a.Employee.LastName))
        }).ToList();
        return View(rows);
    }

    public async Task<IActionResult> PrimaryAssignee()
    {
        var rows = await _context.Tickets.Select(t => new PrimaryAssigneeRow
        {
            TicketId = t.Id, Subject = t.Subject,
            PrimaryAssignee = t.Assignments.Where(a => a.IsPrimary && a.UnassignedAt == null)
                .Select(a => a.Employee.FirstName + " " + a.Employee.LastName).FirstOrDefault() ?? "Unassigned"
        }).OrderBy(r => r.TicketId).ToListAsync();
        return View(rows);
    }

    public async Task<IActionResult> CategoryHierarchy()
    {
        var rows = await _context.TicketCategories.Select(c => new CategoryHierarchyRow
        {
            Category = c.Name,
            ParentCategory = c.ParentCategory != null ? c.ParentCategory.Name : "Root"
        }).OrderBy(r => r.ParentCategory).ThenBy(r => r.Category).ToListAsync();
        return View(rows);
    }
}

public class EmployeeWorkloadRow { public string Employee { get; set; } = ""; public string Department { get; set; } = ""; public int UnresolvedTicketCount { get; set; } }
public class DepartmentWorkloadRow { public string Department { get; set; } = ""; public int EmployeeCount { get; set; } public int UnresolvedTicketCount { get; set; } }
public class UnassignedTicketRow { public int TicketId { get; set; } public string Subject { get; set; } = ""; public string Customer { get; set; } = ""; public string Priority { get; set; } = ""; public string Status { get; set; } = ""; public string CreatedAt { get; set; } = ""; }
public class MultipleAssigneeRow { public int TicketId { get; set; } public string Subject { get; set; } = ""; public int NumberOfActiveAssignees { get; set; } public string Assignees { get; set; } = ""; }
public class PrimaryAssigneeRow { public int TicketId { get; set; } public string Subject { get; set; } = ""; public string PrimaryAssignee { get; set; } = ""; }
public class CategoryHierarchyRow { public string Category { get; set; } = ""; public string ParentCategory { get; set; } = ""; }
