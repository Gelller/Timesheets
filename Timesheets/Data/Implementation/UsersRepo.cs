using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Data.Ef;

namespace Timesheets.Data.Implementation
{
    public class UsersRepo : IUsersRepo
    {
        private readonly TimesheetDbContext _context;
        public UsersRepo(TimesheetDbContext context)
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
            await _context.SaveChangesAsync();
            return item.Id;
        }   
        public async Task<IEnumerable<User>> GetItems()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }
        public async Task Update(User item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Users.FindAsync(id);
            _context.Users.Remove(item);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash)
        {
            return
                await _context.Users
                    .Where(x => x.Username == login && x.PasswordHash == passwordHash)
                    .FirstOrDefaultAsync();
        }
    }
}
