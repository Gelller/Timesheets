using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Data;

namespace Timesheets.Domain.Implementation
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepo _userRepo;

        public UsersManager(IUsersRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<User> GetItem(Guid id)
        {
            return await _userRepo.GetItem(id);
        }
        public async Task<Guid> Create(User item)
        {
            await _userRepo.Add(item);
            return item.Id;
        }
        public async Task<IEnumerable<User>> GetItems()
        {
            return await _userRepo.GetItems();
        }
        public async Task Update(Guid id, User item)
        {
            item.Id = id;
            await _userRepo.Update(item);
        }
    }
}
