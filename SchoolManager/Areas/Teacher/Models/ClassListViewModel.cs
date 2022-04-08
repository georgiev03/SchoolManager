using SchoolManager.Core.Models;

namespace SchoolManager.Areas.Teacher.Models
{
    public class ClassListViewModel
    {
        public IEnumerable<ClassViewModel> Classes { get; set; }
    }
}
