using Microsoft.AspNetCore.Mvc;

namespace salesAdmin.Controllers;

public class SalesController : Controller
{
    public IActionResult CreateRequest()
    {
        return View();
    }
}
