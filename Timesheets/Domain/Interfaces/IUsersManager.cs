using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IUsersManager
    { 
            Task<User> GetItem(Guid id);
            Task<IEnumerable<User>> GetItems();
            Task<Guid> Create(UserDto user);
            Task Update(Guid id, User user);
            Task Delete(Guid id);
            Task<User> GetUser(LoginRequest request);
    }
}
