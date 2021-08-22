using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.UserAggregate
{
    public interface IUserAggregateRepo
    {
        Task <IEnumerable<User>> GetItems();
        Task Update(Guid id, User item);
        Task Delete(Guid id);
        Task<User> GetItem(Guid id);
        Task<Guid> Add(User item);
    }
}
