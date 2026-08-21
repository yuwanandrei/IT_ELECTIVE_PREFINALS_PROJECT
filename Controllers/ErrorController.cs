using Microsoft.AspNetCore.Mvc;

namespace LycevmHelpDesk.Controllers;

public class ErrorController : Controller
{
    public IActionResult Index() => View();
}
