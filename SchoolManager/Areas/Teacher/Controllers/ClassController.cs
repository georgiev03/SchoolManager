using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SchoolManager.Areas.Teacher.Models;
using SchoolManager.Core.Constants;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Areas.Teacher.Controllers
{
    public class ClassController : BaseController
    {
        private readonly IClassService service;
        private readonly UserManager<ApplicationUser> userManager;

        public ClassController(
            IClassService _service,
            UserManager<ApplicationUser> _userManager)
        {
            service = _service;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await service.GetAllClassesAsync();

            return View(new ClassListViewModel
            {
                Classes = classes
            });
        }

        [HttpPost]
        public async Task<IActionResult> JoinClass(string classId)
        {
            var user = await userManager.GetUserAsync(User);
            (string msg, bool success) = await service.JoinClass(classId, user);

            if (success)
            {
                ViewData[MessageConstant.SuccessMessage] = msg;
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = msg;
            }

            return Redirect("/");
        }

    }
}
