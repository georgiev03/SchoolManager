using Microsoft.AspNetCore.Mvc;

namespace SchoolManager.Controllers
{
    public class GradesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
