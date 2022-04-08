using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data;
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

        public async Task<ICollection<ClassListViewModel>> GetAllClasses()
            => await repo.All<Class>()
                .Select(c => new ClassListViewModel()
                {
                    Grade = c.Grade,
                    Letter = c.Letter,
                    Id = c.Id
                })
                .ToListAsync();
    }
}
