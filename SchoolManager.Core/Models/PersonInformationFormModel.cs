using System.ComponentModel.DataAnnotations;
using SchoolManager.Core.CustomAttributes;

namespace SchoolManager.Core.Models
{
    public class PersonInformationFormModel
    {
        [StringLength(15)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(15)]
        [Required]
        public string LastName { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }

        [Required]
        //[DateRange("01/01/1920", "01/01/2017", ErrorMessage = "Date is out of Range")]
        public DateTime Birthdate { get; set; }
    }
}
