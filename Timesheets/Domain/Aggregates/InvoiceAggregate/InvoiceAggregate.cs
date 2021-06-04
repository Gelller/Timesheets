using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.ValueObjects;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.InvoiceAggregate
{
    public class InvoiceAggregate:Invoice
    {
        private readonly decimal _rate = 150;
        private InvoiceAggregate() { }

        public static InvoiceAggregate Create(Guid contractId, DateTime dateStart, DateTime dateEnd)
        {
            return new InvoiceAggregate()
            {
                Id = Guid.NewGuid(),
                ContractId = contractId,
                DateStart = dateStart,
                DateEnd = dateEnd

            };
        }
        public void IncludeSheets(IEnumerable<Sheet> sheets)
        {
           Sheets.AddRange(sheets);
           CalculateSum();
        }
        private void CalculateSum()
        {
            var amount= Sheets.Sum(x => x.Amount * _rate);
         //  Sum = amount;
            Sum = Money.FromDeciaml(amount);
        }
    }
}
