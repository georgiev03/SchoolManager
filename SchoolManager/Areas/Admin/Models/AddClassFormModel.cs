using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Areas.Admin.Models
{
    public class AddClassFormModel
    {
        [Required]
        [Range(1, 12, ErrorMessage = "Grade can start from {1} and end on {2}")]
        public int Grade { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Class name can only be {1} letter")]
        public string Letter { get; set; }
    }
}
