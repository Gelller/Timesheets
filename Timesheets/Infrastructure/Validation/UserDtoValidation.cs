using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class UserDtoValidation:AbstractValidator<UserDto>
    {
        public UserDtoValidation()
        {
            RuleFor(x => x.Username)
              .NotEmpty();
            RuleFor(x => x.Password)
            .NotEmpty();
            RuleFor(x => x.Role)
            .NotEmpty();

        }
    }
}
