using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManager.Infrastructure.Data
{
    public class TeacherClass
    {
        [ForeignKey(nameof(Teacher))]
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey(nameof(Class))]
        public string ClassId { get; set; }
        public Class Class { get; set; }
    }
}
