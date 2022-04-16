using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;

namespace SchoolManager.Controllers
{
    public class SchoolController : BaseController
    {
        private readonly ISchoolService service;

        public SchoolController(ISchoolService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Info()
        {
            SchoolInfoVewModel schoolInfoModel = await service.GetSchoolInfo();

            return View(schoolInfoModel);
        }
    }
}
