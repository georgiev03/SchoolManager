using Microsoft.Build.Framework;

namespace SchoolManager.Areas.Teacher.Models
{
    public class AddTeacherToClassFormModel
    {
        [Required]
        public string ClassId { get; set; }
    }
}
