using Timesheets.Models.Dto.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Models;
using System.Security.Cryptography;

namespace Timesheets.Domain.Aggregates.UserAggregate
{
    public class UserAggregateRepo:IUserAggregateRepo
    {
        private readonly TimesheetDbContext _context;
        public UserAggregateRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetItem(Guid id)
        {
            var result = await _context.Users.FindAsync(id);
            return result;
        }
        public async Task<Guid> Add(User item)
        {
            await _context.Users.AddAsync(item);

            RefreshToken token = new RefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = item.Id,
                Expiration = DateTime.Now.AddDays(100),
                Token = GenerateRefreshToken()

            };

            await _context.RefreshToken.AddAsync(token);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
