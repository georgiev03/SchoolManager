using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManager.Infrastructure.Data;

namespace SchoolManager.Core.Models
{
	public class StudentViewModel
	{
        public string Id { get; set; }

        public string FullName { get; set; }

        public ICollection<double> Marks { get; set; } = new List<double>();
    }
}
