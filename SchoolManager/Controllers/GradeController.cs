using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Contracts;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Controllers
{
    public class GradeController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly IGradeService gradeService;
        public GradeController(
            IGradeService _gradeService,
            UserManager<ApplicationUser> _userManager)
        {
            gradeService = _gradeService;
            userManager = _userManager;
        }

        public IActionResult ShowGrades()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            gradeService.GetGradesBySubject(user);

            return View();
        }
    }
}
