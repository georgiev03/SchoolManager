using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Controllers
{
    public class GradesController : Controller
    {
        private readonly IGradeService service;
        private readonly UserManager<ApplicationUser> userManager;


        public GradesController(
            IGradeService _service,
            UserManager<ApplicationUser> _userManager)
        {
            service = _service;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var gradesMarksList = await service.GetStudentMarks(user);

            var marks = new StudentMarksViewModel()
            {
                Marks = gradesMarksList
            };

            return View(marks);
        }
    }
}
