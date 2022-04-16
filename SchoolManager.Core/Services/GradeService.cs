using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data;
using SchoolManager.Infrastructure.Data.Enums;
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

        public async Task<IEnumerable<StudentGradesMarksViewModel>> GetStudentMarks(ApplicationUser user)
        {
            //new Dictionary<Subject, List<double>>()
            //{
            //    [Subject.Bulgarian] = new List<double>(),
            //    [Subject.English] = new List<double>(),
            //    [Subject.IT] = new List<double>(),
            //    [Subject.Maths] = new List<double>(),
            //    [Subject.PE] = new List<double>(),
            //};

            var students = await repo.All<Grade>()
                .Where(g => g.StudentId == user.Id)
                .GroupBy(g => g.Subject)
                //.Select(d => marks[d.Key].Add(d.Select(m => m.Mark)));
            .Select(g => new StudentGradesMarksViewModel()
             {
                 Subject = g.Key.ToString(),
                 Marks = g.Select(e => e.Mark),
                 AvgMark = g.Select(e => e.Mark).Average()

             })
                .ToListAsync();

            return students;
        }
    }
}
