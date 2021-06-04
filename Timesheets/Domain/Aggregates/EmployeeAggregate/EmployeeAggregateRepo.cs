using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.EmployeeAggregate
{
    public class EmployeeAggregateRepo : IEmployeeAggregateRepo
    {
        private readonly TimesheetDbContext _context;
        public EmployeeAggregateRepo(TimesheetDbContext context)
        {
            _context = context;
        }
       
        public async Task<Guid> Add(Employee item)
        {
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            var result = await _context.Employees.FindAsync(id);
            return result;
        }
        public async Task<IEnumerable<Employee>> GetItems()
        {
            var result = await _context.Employees.ToListAsync();
            return result;
        }
    }
}
