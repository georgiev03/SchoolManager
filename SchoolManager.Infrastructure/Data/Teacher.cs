using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Infrastructure.Data
{
    public class Teacher
    {
        [Key]
        public Guid StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<TeacherClass> TeacherClasses { get; set; } = new HashSet<TeacherClass>();
    }
}
