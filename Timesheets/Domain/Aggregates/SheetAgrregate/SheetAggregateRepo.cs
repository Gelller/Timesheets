using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.SheetAgrregate
{
    public class SheetAggregateRepo : ISheetAggregateRepo
    {
        private readonly TimesheetDbContext _context;

        public SheetAggregateRepo(TimesheetDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Add(Sheet item)
        {
            await _context.Sheets.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<Sheet> Approve(Guid sheetId)
        {
            var result = await _context.Sheets.FindAsync(sheetId);
            return result;
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Sheets.FindAsync(id);
            _context.Sheets.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            var result = await _context.Sheets.FindAsync(id);
            return (SheetAggregate)result;
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            var result = await _context.Sheets.ToListAsync();
            return result;
        }

        public async Task Update(Guid id, Sheet item)
        {
            var sheet = SheetAggregate.Update(id, item);
            _context.Sheets.Update(sheet);
            await _context.SaveChangesAsync();
        }
    }
}
