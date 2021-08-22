using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Data.Interfaces
{
    public interface  IRefreshTokenRepo:IRepoBase<RefreshToken>
    {
    }
}
