using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        
        private readonly ISchoolService service;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment env;

        public HomeController(
            ISchoolService _service,
            UserManager<ApplicationUser> _userManager,
            IWebHostEnvironment _env)
        {
            service = _service;
            userManager = _userManager;
            env = _env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult UpdateSchoolInfo()
        {
            return View(new SchoolViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSchoolInfo(SchoolViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = await userManager.GetUserAsync(User);
            await service.UpdateSchoolInfo(model, user);

            return Redirect("/");
        }

       
    }
}
