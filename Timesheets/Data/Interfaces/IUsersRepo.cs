using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data;

namespace Timesheets.Data.Interfaces
{
    public interface IUsersRepo : IRepoBase<User>
    {
    }
}
