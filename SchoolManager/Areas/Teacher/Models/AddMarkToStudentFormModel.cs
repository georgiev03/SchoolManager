using System.ComponentModel.DataAnnotations;
using SchoolManager.Infrastructure.Data.Enums;

namespace SchoolManager.Areas.Teacher.Models
{
    public class AddMarkToStudentFormModel
    {
        [Required]
        public string StudentId { get; set; }

        [Required]
        public string Mark { get; set; }

        public Subject Subject { get; set; }
    }
}
