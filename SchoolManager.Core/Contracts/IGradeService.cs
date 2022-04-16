using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Core.Contracts
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeViewModel>> GetGradesBySubject(ApplicationUser user);

        Task<IEnumerable<StudentGradesMarksViewModel>> GetStudentMarks(ApplicationUser user);
    }
}
