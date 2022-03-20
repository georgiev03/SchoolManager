using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Infrastructure.Data
{
    public class Class
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public char Letter { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public ICollection<TeacherClass> TeacherClasses { get; set; } = new HashSet<TeacherClass>();
    }
}
