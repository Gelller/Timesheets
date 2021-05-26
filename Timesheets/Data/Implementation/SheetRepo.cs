using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Timesheets.Data.Implementation
{
    public class SheetRepo : ISheetRepo
    {
        private readonly TimesheetDbContext _context;

        public SheetRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            var result = await _context.Sheets.FindAsync(id);

            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            var result = await _context.Sheets.ToListAsync();

            return result;
        }

        public async Task<Guid> Add(Sheet item)
        {
            await _context.Sheets.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task Update(Sheet item)
        {
            _context.Sheets.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var item = await _context.Sheets.FindAsync(id);
            _context.Sheets.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sheet>> GetItemsForInvoice(Guid contractId, DateTime dateStatr, DateTime dateEnd)
        {
            var sheets =await  _context.Sheets.Where(x => x.ContractId == contractId)
                .Where(x => x.Date <= dateEnd && x.Date >= dateStatr)
                .Where(x=>x.InvoiceId == null).ToListAsync();
            return sheets;
        }
    }
}
