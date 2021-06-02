using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Data.Ef;
using Microsoft.EntityFrameworkCore;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Domain.Aggregates.SheetAgrregate;

namespace Timesheets.Data.Implementation
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly TimesheetDbContext _context;   
        public InvoiceRepo(TimesheetDbContext context)
        {
            _context = context;
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
        public async Task<Guid> Add(Invoice item)
        {
            await _context.Invoice.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }
        public async Task Update(Invoice item)
        {
            _context.Invoice.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var item = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(item);
            await _context.SaveChangesAsync();
        }


        public Task Update(InvoiceAggregate item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SheetAggregate>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }

     
    }
}
