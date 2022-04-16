using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Core.Models
{
    public class SchoolInfoVewModel : SchoolViewModel
    {
        [DisplayName("Principal")]
        public string PrincipalNames { get; set; }
    }
}
