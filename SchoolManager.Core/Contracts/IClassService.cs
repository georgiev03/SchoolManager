using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SchoolManager.Core.Models;

namespace SchoolManager.Core.Contracts
{
    public interface IClassService
    {
        Task GenerateClasses();

        Task<ICollection<ClassListViewModel>> GetAllClasses();
    }
}
