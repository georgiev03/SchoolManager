using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManager.Core.Models;

namespace SchoolManager.Areas.Admin.Models
{
    public class UserListingsViewModel
    {
        public IEnumerable<UserListViewModel> Users { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
