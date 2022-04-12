using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Core.Contracts
{
    public interface IClassService
    {
        Task GenerateClasses();

        Task<ICollection<ClassViewModel>> GetAllClassesAsync();

        Task<(string, bool)> JoinClass(string classId, ApplicationUser user);

        Task<ICollection<ClassViewModel>> GetAllClassesForATeacherAsync(ApplicationUser user);

        Task<IEnumerable<StudentViewModel>> GetAllStudentsFromClassAsync(string classId, ApplicationUser user);
    }
}
