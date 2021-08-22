using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Aggregates.EmployeeAggregate;
using Xunit;

namespace TimesheetsTests
{
    public class EmployeeAggregateTests
    {
        [Fact]
        public void CreateTest()
        {
            var builder = new EmployeeAggregateBuilder();
            var employee = EmployeeAggregate.Create(
                builder.userId,
                builder.isDelete);

            employee.Should().As<EmployeeAggregate>();
        }
        [Fact]
        public void EmployeeUpdateTest()
        {
            var employeeBuilder = new EmployeeAggregateBuilder();
            var employeeAggregate = employeeBuilder.GetRandomEmployeeAggregate();
            var employee = EmployeeAggregate.Update(employeeAggregate.Id, employeeAggregate);
            employeeAggregate.Should().BeEquivalentTo(employee);
        }
    }
}
