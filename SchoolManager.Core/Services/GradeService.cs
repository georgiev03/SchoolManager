using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data;
using SchoolManager.Infrastructure.Data.Identity;
using SchoolManager.Infrastructure.Data.Repositories;

namespace SchoolManager.Core.Services
{
    public class GradeService : IGradeService
    {
        private readonly IApplicationDbRepository repo;

        public GradeService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<GradeViewModel>> GetGradesBySubject(ApplicationUser user)
        {
            var grades = repo.All<Grade>()
                .Where(g => "g.StudentId" == user.Id);

            return new List<GradeViewModel>();
        }
    }
}
