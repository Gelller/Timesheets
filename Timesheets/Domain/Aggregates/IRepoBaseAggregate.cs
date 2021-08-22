using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Domain.Aggregates
{
    public interface IRepoBaseAggregate<T>
    {
        Task<T> GetItem(Guid id);
        Task<IEnumerable<T>> GetItems();
        Task<Guid> Add(T item);
        Task Update(T item);
        Task Delete(Guid id);
    }
}
