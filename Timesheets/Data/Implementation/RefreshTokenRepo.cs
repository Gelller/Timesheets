using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Data.Implementation
{
    public class RefreshTokenRepo : IRefreshTokenRepo
    {
        private readonly TimesheetDbContext _context;
        public RefreshTokenRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        public Task<Guid> Add(RefreshToken item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshToken> GetItem(Guid id)
        {
            var result = await _context.RefreshToken.Where(x => x.UserId == id).FirstOrDefaultAsync();
            return result;
        }

        public Task<IEnumerable<RefreshToken>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task Update(RefreshToken item)
        {
            throw new NotImplementedException();
        }
    }
}
