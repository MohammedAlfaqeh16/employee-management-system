using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asp.netCore_project.Areas.Employees.Controllers
{
    [Authorize]
    [Area("Employees")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
