using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Aggregates.SheetAgrregate;

namespace Timesheets.Domain.Aggregates.InvoiceAggregate
{
    public class InvoiceAggregateRepo : IInvoiceAggregateRepo
    {
        private readonly TimesheetDbContext _context;

        public InvoiceAggregateRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetItems()
        {
            var result = await _context.Invoice.ToListAsync();
            return null;
        }

        public async Task<IEnumerable<Sheet>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd)
        {
            var sheets = await _context.Sheets.Where(x => x.ContractId == contractId)
              .Where(x => x.Date <= dateEnd && x.Date >= dateStart)
              .Where(x => x.InvoiceId == null).ToListAsync();

            return sheets;
        }

       
    }
}
