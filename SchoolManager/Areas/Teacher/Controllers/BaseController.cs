using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Constants;

namespace SchoolManager.Areas.Teacher.Controllers
{
    [Authorize(Roles = UserConstants.Roles.Teacher)]
    [Area("Teacher")]
    public class BaseController : Controller
    {
        
    }
}
