using Microsoft.AspNetCore.Mvc;

namespace SchoolManager.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
