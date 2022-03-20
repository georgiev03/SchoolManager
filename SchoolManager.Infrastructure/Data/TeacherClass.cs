using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManager.Infrastructure.Data
{
    public class TeacherClass
    {
        [ForeignKey(nameof(Teacher))]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [ForeignKey(nameof(Class))]
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
    }
}
