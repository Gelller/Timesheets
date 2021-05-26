using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class SheetDtoValidator : AbstractValidator<SheetDto>
    {
        public SheetDtoValidator()
        {
            RuleFor(x => x.Amount)
                .InclusiveBetween(1, 8)
                .WithMessage(ValidationMessages.SheetAmountError);

            RuleFor(x => x.ContractId)
              .NotEmpty();
            RuleFor(x => x.EmployeeId)
            .NotEmpty();
            RuleFor(x => x.ServiceId)
            .NotEmpty();

        }
    }
}
