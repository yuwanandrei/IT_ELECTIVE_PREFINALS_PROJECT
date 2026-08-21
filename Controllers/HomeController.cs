using LycevmHelpDesk.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LycevmHelpDesk.Controllers;

public class HomeController : Controller
{
    private readonly HelpDeskContext _context;
    public HomeController(HelpDeskContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        ViewBag.Departments = await _context.Departments.CountAsync();
        ViewBag.Employees = await _context.Employees.CountAsync();
        ViewBag.Customers = await _context.Customers.CountAsync();
        ViewBag.Tickets = await _context.Tickets.CountAsync();
        return View();
    }
}
