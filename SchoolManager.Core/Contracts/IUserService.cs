using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManager.Core.Models;
using SchoolManager.Infrastructure.Data.Enums;
using SchoolManager.Infrastructure.Data.Identity;

namespace SchoolManager.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsersAsync();
        Task MakeUserTeacher(ApplicationUser user, Subject subject);
        Task UpdateUserInformation(PersonInformationFormModel model, ApplicationUser user);
    }
}
