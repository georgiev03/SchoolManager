using SchoolManager.Core.Models;

namespace SchoolManager.Areas.Teacher.Models
{
	public class StudentListViewModel
	{
        public IEnumerable<StudentViewModel> Students { get; set; }
	}
}
