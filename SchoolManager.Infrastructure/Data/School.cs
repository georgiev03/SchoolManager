using System.ComponentModel.DataAnnotations;

namespace SchoolManager.Infrastructure.Data
{
    public class School
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public string Information { get; set; }

        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
    }
}
