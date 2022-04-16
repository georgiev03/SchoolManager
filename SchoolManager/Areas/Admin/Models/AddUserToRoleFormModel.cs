using System.ComponentModel.DataAnnotations;
using SchoolManager.Infrastructure.Data.Enums;

namespace SchoolManager.Areas.Admin.Models
{
    public class AddUserToRoleFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
