using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data;
using SchoolManager.Infrastructure.Data.Common;
using SchoolManager.Infrastructure.Data.Identity;
using SchoolManager.Infrastructure.Data.Repositories;

namespace SchoolManager.Core.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IApplicationDbRepository repo;

        public SchoolService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task UpdateSchoolInfo(SchoolViewModel model, ApplicationUser user)
        {
            var principal = new Principal()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

            var school = new School()
            {
                Name = model.Name,
                Information = model.Information,
                Location = model.Location,
                Principal = principal,
                Image = model.ImageUrl
            };

            if (!repo.All<Principal>().Any(p => p.Id == user.Id))
            {
                await repo.AddAsync(principal);
            }
            if (!repo.All<School>().Any(s => s.PrincipalId == principal.Id))
            {
                await repo.AddAsync(school);
            }

            await repo.SaveChangesAsync();

            school.PrincipalId = principal.Id;
            principal.SchoolId = school.Id;

            repo.Update(school);
            repo.Update(principal);

            await repo.SaveChangesAsync();
        }

        public async Task<SchoolInfoVewModel> GetSchoolInfo()
           => (await repo.All<School>()
               .Include(s => s.Principal)
               .Where(s => s.Id == "7ba4bb38-51e9-439c-99d8-d6a4f925e1df")
               .Select(s => new SchoolInfoVewModel()
               {
                   Name = s.Name,
                   Information = s.Information,
                   Location = s.Location,
                   ImageUrl = s.Image,
                   PrincipalNames = s.Principal.FirstName +" " + s.Principal.LastName,
               })
               .FirstOrDefaultAsync())!;
    }
}
