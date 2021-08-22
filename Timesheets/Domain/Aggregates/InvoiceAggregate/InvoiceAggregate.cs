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
            decimal sum = 0;
            for (int i = 0; i < Sheets.Count(); i++)
            {
                sum += Sheets[i].Amount;
            }
            Sum = Money.FromDeciaml(sum * _rate);
        }

        public static InvoiceAggregate Update(Guid id, Invoice invoice)
        {
            return new InvoiceAggregate()
            {
                Id = id,
                ContractId = invoice.ContractId,
                DateStart = invoice.DateStart,
                DateEnd = invoice.DateEnd

            };
        }
    }
}
