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
        public Task<Guid> Add(SheetAggregate item)
        {
            throw new NotImplementedException();
        }

        public async Task<Sheet> Approve(Guid sheetId)
        {
            var result = await _context.Sheets.FindAsync(sheetId);
            return result;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SheetAggregate> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SheetAggregate>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task Update(SheetAggregate item)
        {
            _context.Sheets.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
