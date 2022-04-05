using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManager.Infrastructure.Data
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Subject { get; set; }

        [Required]
        public double Mark { get; set; }


        [Required]
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
