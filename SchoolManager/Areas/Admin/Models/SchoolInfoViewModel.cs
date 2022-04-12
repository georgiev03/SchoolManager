using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManager.Infrastructure.Data;

namespace SchoolManager.Areas.Admin.Models
{
    public class SchoolInfoViewModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Location { get; set; }

        public string Information { get; set; }

        public string PrincipalId { get; set; }
    }
}
