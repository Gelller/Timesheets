using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class EmployeeDtoValidation:AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidation()
        {
            RuleFor(x => x.IsDeleted)
              .NotEmpty();
        }
    }
}
