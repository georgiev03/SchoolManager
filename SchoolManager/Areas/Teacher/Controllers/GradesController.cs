using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManager.Areas.Teacher.Models;
using SchoolManager.Core.Constants;
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
            var teacher = await service.GetTeacherAsync(user);

            var marks = new double[] { 2, 3, 4, 5, 6 }
                .Select(r => new SelectListItem
                {
                    Text = r.ToString(),
                    Value = r.ToString()
                });

            return View("ChildrenForm", new StudentListViewModel
            {
                Students = students,
                Marks = marks,
                Subject = teacher.Subject
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddMark(AddMarkToStudentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong, please try again";

                return View("ChildrenForm");
            }

            var student = await userManager.FindByIdAsync(model.StudentId);

            try
            {
                await service.AddMarkToStudentAsync(student, model.Mark, model.Subject);
            }
            catch (Exception)
            {
                ViewData[MessageConstant.ErrorMessage] = "Something went wrong, please try again";
            }

            return Redirect("/");
        }


    }
}
