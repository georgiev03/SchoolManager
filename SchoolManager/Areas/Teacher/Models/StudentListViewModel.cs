using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Enums;

namespace SchoolManager.Areas.Teacher.Models
{
	public class StudentListViewModel
	{
		public IEnumerable<StudentViewModel> Students { get; set; }

		public IEnumerable<SelectListItem> Marks { get; set; }

        public Subject Subject { get; set; }
	}
}
