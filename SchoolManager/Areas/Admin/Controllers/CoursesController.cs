using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Areas.Admin.Models;
using SchoolManager.Core.Contracts;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Areas.Admin.Controllers
{
    public class CoursesController : BaseController
    {

        private readonly IClassService service;


        public CoursesController(
            IClassService _service)
        {
            service = _service;
        }

        //public IActionResult CreateClass()
        //{
        //    return View(new AddClassFormModel());
        //}

        public IActionResult GenerateClasses()
        {
            service.GenerateClasses();

            return Redirect("/");
        }

    }
}
