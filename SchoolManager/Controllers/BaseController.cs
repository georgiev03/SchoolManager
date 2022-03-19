using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManager.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
