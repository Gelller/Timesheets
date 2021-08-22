using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Aggregates.EmployeeAggregate;

namespace TimesheetsTests
{
    class EmployeeAggregateBuilder
    {
        public Guid userId = Guid.Parse("38e87365-5030-4ba5-b5bb-e3334c6cbc7f");
        public bool isDelete = RandomBool();

        public EmployeeAggregate GetRandomEmployeeAggregate()
        {
            var employeeAggregate = EmployeeAggregate.Create(userId, isDelete);
            return employeeAggregate;
        }

        public static bool RandomBool()
        {
            Random random = new Random();
            var randomBool = random.Next(1, 101);
            if (randomBool > 50)
                return true;
            else
                return false;
        }
    }
}
