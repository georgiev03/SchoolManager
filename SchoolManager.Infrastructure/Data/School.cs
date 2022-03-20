using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Infrastructure.Data
{
    public class School
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string Information { get; set; }

        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
    }
}
