using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SchoolManager.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(15)]
        public string? FirstName { get; set; }

        [StringLength(15)]
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }

        public DateTime? Birthdate { get; set; }

        public ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();

        [ForeignKey(nameof(Class))]
        public string? ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
