using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace SchoolManager.Infrastructure.Data
{
    public class School
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Location { get; set; }

        public string Information { get; set; }

        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();

        [ForeignKey(nameof(Principal))]
        public string? PrincipalId { get; set; }
        public Principal? Principal { get; set; }
    }
}
