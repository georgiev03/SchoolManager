using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Core.Models
{
    public class GradeViewModel
    {
        public string Subject { get; set; }

        public List<double> Marks { get; set; }

    }
}
