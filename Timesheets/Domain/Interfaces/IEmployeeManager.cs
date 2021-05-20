using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee> GetItem(Guid id);
        Task<IEnumerable<Employee>> GetItems();
        Task<Guid> Create(Employee employee);
        Task Update(Guid id, Employee employee);
    }
}
