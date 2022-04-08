using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Constants;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Identity;
using SchoolManager.Models;

namespace SchoolManager.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService service;

        public UserController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            service = _service;

            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Information()
        {
            return View(new PersonInformationFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Information(PersonInformationFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);

            await service.UpdateUserInformation(model, user);

            return Redirect("/");
        }
    }
}
