using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SchoolManager.Core.Models
{
    public class SchoolViewModel
    {
        [Required]
        [StringLength(150)]
        [DisplayName("School name")]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Location { get; set; }

        public string Information { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }
    }
}
