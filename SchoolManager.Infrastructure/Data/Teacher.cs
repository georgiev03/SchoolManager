using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Infrastructure.Data
{
    public class Teacher
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<TeacherClass> TeacherClasses { get; set; } = new HashSet<TeacherClass>();
    }
}
