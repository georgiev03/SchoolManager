using Microsoft.AspNetCore.Mvc;
using SchoolManager.Areas.Admin.Models;

namespace SchoolManager.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        //public Task<IActionResult> UpdateSchoolInfo()
        //{
        //    return View(new SchoolInfoViewModel());
        //}
    }
}
