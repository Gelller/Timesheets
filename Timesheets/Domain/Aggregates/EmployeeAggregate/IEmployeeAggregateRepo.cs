using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.EmployeeAggregate
{
    public interface IEmployeeAggregateRepo
    {
        Task<Employee> GetItem(Guid id);
        Task<IEnumerable<Employee>> GetItems();
        Task<Guid> Add(Employee item);
        Task Update(Guid id, Employee item);
        Task Delete(Guid id);
    }
}
