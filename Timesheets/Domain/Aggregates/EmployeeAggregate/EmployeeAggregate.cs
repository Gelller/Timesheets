using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.EmployeeAggregate
{
    public class EmployeeAggregate : Employee
    {
        private EmployeeAggregate() { }

        public static EmployeeAggregate Create(Guid userId, bool isDeleted)
        {
            return new EmployeeAggregate()
            {
                Id = Guid.NewGuid(),
                UserId= userId,
                IsDeleted=isDeleted

            };
        }
    }
}
