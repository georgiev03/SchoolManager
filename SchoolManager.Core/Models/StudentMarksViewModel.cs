using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Core.Models
{
    public class StudentMarksViewModel
    {
        public IEnumerable<StudentGradesMarksViewModel> Marks { get; set; }
            
    }
}
