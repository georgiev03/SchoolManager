using Microsoft.AspNetCore.Mvc;
using SchoolManager.Areas.Teacher.Models;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;

namespace SchoolManager.Areas.Teacher.Controllers
{
    public class ClassController : BaseController
    {
        private readonly IClassService service;

        public ClassController(
            IClassService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Index()
        {
            var classes = await service.GetAllClassesAsync();

            return View(new ClassListViewModel
            {
                Classes = classes
            });
        }

        //[HttpPost]
        //public async Task<IActionResult> JoinClass()
        //{
        //    var teacher = User.Identity;
        //}

    }
}
