using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Identity;
using SchoolManager.Infrastructure.Data.Repositories;

namespace SchoolManager.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;

        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsersAsync()
        {
            return await repo.All<ApplicationUser>()
               .Select(u => new UserListViewModel()
               {
                   Email = u.Email,
                   Id = u.Id,
                   Name = $"{u.FirstName} {u.LastName}"
               })
               .ToListAsync();
        }
    }
}
