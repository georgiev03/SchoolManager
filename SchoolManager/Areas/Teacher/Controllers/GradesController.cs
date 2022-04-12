using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Areas.Teacher.Models;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Services;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Areas.Teacher.Controllers
{
    public class GradesController : BaseController
    {
        private readonly IClassService service;
        private readonly UserManager<ApplicationUser> userManager;

        public GradesController(
            IClassService _service,
            UserManager<ApplicationUser> _userManager)
        {
            service = _service;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var classes = await service.GetAllClassesForATeacherAsync(user);

            return View(new ClassListViewModel
            {
                Classes = classes
            });
        }

		//TODO: Create class-student list
		public async Task<IActionResult> ClassInfo(string classId)
        {
            var user = await userManager.GetUserAsync(User);
            var students = await service.GetAllStudentsFromClassAsync(classId, user);

            return View("ChildrenForm", new StudentListViewModel
            {
                Students = students
            });
        }

	}
}
