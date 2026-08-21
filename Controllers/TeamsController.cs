using LycevmHelpDesk.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LycevmHelpDesk.Controllers;

public class TeamsController : Controller
{
    private readonly HelpDeskContext _context;
    public TeamsController(HelpDeskContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        var teams = await _context.Teams
            .Include(t => t.Department)
            .Include(t => t.Members).ThenInclude(m => m.Employee)
            .OrderBy(t => t.Name).ToListAsync();
        return View(teams);
    }
}
