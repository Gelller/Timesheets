using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.UserAggregate
{
    public interface IUserAggregateRepo
    {
        Task<User> GetItem(Guid id);
        Task<Guid> Add(User item);
    }
}
