using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Infrastructure.Validation
{
    public static class ValidationMessages
    {
        public const string SheetAmountError = "Amount should be between 1 and 8 hours";
        public const string InvalidValue = "Incorrect value";
        public const string InvoiceDateStartError = "Start date should be less than or equal to the end date";
        public const string InvoiceDateEndError = "End date should be greater than or equal to the start date";
    }
}
