using Microsoft.AspNetCore.Mvc;

namespace TestingTeleric.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
