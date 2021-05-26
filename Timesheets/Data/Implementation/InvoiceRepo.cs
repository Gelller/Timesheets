using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Data.Ef;


namespace Timesheets.Data.Implementation
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly TimesheetDbContext _context;   
        public InvoiceRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Add(Invoice item)
        {
            await _context.Invoice.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task Update(Invoice item)
        {
            throw new NotImplementedException();
        }
    }
}
