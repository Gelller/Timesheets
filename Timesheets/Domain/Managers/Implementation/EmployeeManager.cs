using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Data;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Domain.Aggregates.EmployeeAggregate;

namespace Timesheets.Domain.Managers.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeAggregateRepo _employeeAggregateRepo;
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeManager(IEmployeeAggregateRepo employeeAggregateRepo, IEmployeeRepo employeeRepo)
        {
            _employeeAggregateRepo = employeeAggregateRepo;
            _employeeRepo = employeeRepo;
        }
        public async Task<Guid> Create(Employee item)
        {
            var employee = EmployeeAggregate.Create(item.UserId,item.IsDeleted);
            await _employeeAggregateRepo.Add(employee);
            return employee.Id;
        }     
        public async Task<Employee> GetItem(Guid id)
        {
            return await _employeeAggregateRepo.GetItem(id);
        }
        public async Task<IEnumerable<Employee>> GetItems()
        {
            return await _employeeAggregateRepo.GetItems();
        }
        public async Task Update(Guid id, Employee employee)
        {
            await _employeeAggregateRepo.Update(id, employee);
        }
        public async Task Delete(Guid id)
        {
            await _employeeAggregateRepo.Delete(id);
        }
    }
}
