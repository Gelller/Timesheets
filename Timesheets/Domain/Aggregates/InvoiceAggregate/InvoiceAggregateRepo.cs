using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Aggregates.SheetAgrregate;
using AutoMapper;

namespace Timesheets.Domain.Aggregates.InvoiceAggregate
{
    public class InvoiceAggregateRepo : IInvoiceAggregateRepo
    {
        private readonly TimesheetDbContext _context;

        public InvoiceAggregateRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(Invoice item)
        {
            await _context.Invoice.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Invoice> GetItem(Guid id)
        {
            var result = await _context.Invoice.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<Invoice>> GetItems()
        {
            var result = await _context.Invoice.ToListAsync();    
            return result;
        }

        public async Task<IEnumerable<Sheet>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd)
        {
            var sheets = await _context.Sheets.Where(x => x.ContractId == contractId)
              .Where(x => x.Date <= dateEnd && x.Date >= dateStart)
              .Where(x => x.InvoiceId == null).ToListAsync();

            return sheets;
        }

        public async Task Update(Guid id, Invoice item)
        {
            var invoice=InvoiceAggregate.Update(id, item);
            _context.Invoice.Update(invoice);
            await _context.SaveChangesAsync();
        }
    }
}
