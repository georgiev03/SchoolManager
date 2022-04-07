using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace SchoolManager.Core.Contracts
{
    public interface IClassService
    {
        Task GenerateClasses();
    }
}
