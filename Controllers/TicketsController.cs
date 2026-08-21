using LycevmHelpDesk.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LycevmHelpDesk.Controllers;

public class TicketsController : Controller
{
    private readonly HelpDeskContext _context;
    public TicketsController(HelpDeskContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        var tickets = await _context.Tickets
            .Include(t => t.Customer).Include(t => t.Category)
            .Include(t => t.Priority).Include(t => t.Status)
            .OrderByDescending(t => t.CreatedAt).ToListAsync();
        return View(tickets);
    }

    public async Task<IActionResult> Details(int id)
    {
        var ticket = await _context.Tickets
            .Include(t => t.Customer).Include(t => t.Category).ThenInclude(c => c.ParentCategory)
            .Include(t => t.Priority).Include(t => t.Status)
            .Include(t => t.Assignments).ThenInclude(a => a.Employee)
            .Include(t => t.Comments).ThenInclude(c => c.Employee)
            .Include(t => t.Attachments)
            .Include(t => t.TicketTags).ThenInclude(tt => tt.Tag)
            .AsSplitQuery()
            .FirstOrDefaultAsync(t => t.Id == id);

        if (ticket is null) return NotFound();
        return View(ticket);
    }
}
