using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data;
using SchoolManager.Infrastructure.Data.Identity;
using SchoolManager.Infrastructure.Data.Repositories;

namespace SchoolManager.Core.Services
{
    public class ClassService : IClassService
    {
        private readonly IApplicationDbRepository repo;

        public ClassService(
            IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task GenerateClasses()
        {
            List<Class> classes = new List<Class>();

            for (int grade = 1; grade <= 12; grade++)
            {
                for (int letter = 'a'; letter <= 'd'; letter++)
                {
                    classes.Add(new Class()
                    {
                        Grade = grade,
                        Letter = (char)letter
                    });
                }
            }

            await repo.AddRangeAsync(classes);

            repo.SaveChanges();
        }

        public async Task<ICollection<ClassViewModel>> GetAllClassesAsync()
            => await repo.All<Class>()
                .Select(c => new ClassViewModel()
                {
                    Grade = c.Grade,
                    Letter = c.Letter,
                    Id = c.Id
                })
                .OrderBy(c => c.Grade)
                .ThenBy(c => c.Letter)
                .ToListAsync();

        public async Task<(string, bool)> JoinClass(string classId, ApplicationUser user)
        {
            var _class = await repo.GetByIdAsync<Class>(classId);
            //var teacher = await repo.GetByIdAsync<Teacher>(user.Id);
            var teacher = repo.All<Teacher>()
                .Where(t => t.Id == user.Id)
                .Include(t => t.TeacherClasses)
                .FirstOrDefault();

            bool success = true;
            string message = $"You successfully joined {_class.Grade} {_class.Letter} class";

            if (teacher.TeacherClasses.Any(tc => tc.Class == _class))
            {
                message = $"You are already teaching {_class.Grade} {_class.Letter} class";
                success = false;
            }
            else if (teacher.TeacherClasses.Count == 8)
            {
                message = "You can only teach up to 8 classes";
                success = false;
            }
            else
            {
                teacher.TeacherClasses.Add(new TeacherClass()
                {
                    Teacher = teacher,
                    Class = _class
                });
            }

            repo.Update(teacher);
            await repo.SaveChangesAsync();

            return (message, success);
        }

        public async Task<ICollection<ClassViewModel>> GetAllClassesForATeacherAsync(ApplicationUser user)
        {
            var teacher = await repo.GetByIdAsync<Teacher>(user.Id);

            return await repo.All<Class>()
                .Where(c => c.TeacherClasses.Any(tc => tc.Teacher == teacher))
                .Select(c => new ClassViewModel()
                {
                    Grade = c.Grade,
                    Letter = c.Letter,
                    Id = c.Id
                })
                .OrderBy(c => c.Grade)
                .ThenBy(c => c.Letter)
                .ToListAsync();
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllStudentsFromClassAsync(string classId, ApplicationUser user)
        {
            var teacher = await repo.GetByIdAsync<Teacher>(user.Id);


            return await repo.All<ApplicationUser>()
                .Where(s => s.ClassId == classId)
                .Include(s => s.Grades)
                .Select(s => new StudentViewModel()
                {
                    FullName = s.FirstName + " " + s.LastName,
                    Marks = s
                        .Grades
                        .Where(g => g.Subject == teacher.Subject)
                        .Select( g=> g.Mark)
                        .ToList(),
                    Id = s.Id
                })
                .ToListAsync();
        }
    }
}
