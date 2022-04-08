using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Areas.Admin.Models
{
    public class AddUserToRoleFormModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
