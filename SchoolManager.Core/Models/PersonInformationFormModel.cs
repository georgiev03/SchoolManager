using System.ComponentModel.DataAnnotations;
using SchoolManager.Core.CustomAttributes;

namespace SchoolManager.Core.Models
{
    public class PersonInformationFormModel
    {
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(25)]
        [Required]
        public string LastName { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }
    }
}
