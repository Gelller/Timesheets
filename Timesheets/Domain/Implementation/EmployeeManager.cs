﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Data;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Domain.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeManager(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<Guid> Create(Employee employee)
        {
            await _employeeRepo.Add(employee);
            return employee.Id;
        }
        public async Task<Employee> GetItem(Guid id)
        {
            return await _employeeRepo.GetItem(id);
        }
        public async Task<IEnumerable<Employee>> GetItems()
        {
            return await _employeeRepo.GetItems();
        }
        public async Task Update(Guid id, Employee employee)
        {
            employee.Id = id;
            await _employeeRepo.Update(employee);
        }
    }
}
