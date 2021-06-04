using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.SheetAgrregate
{
  //  public interface ISheetAggregateRepo:IRepoBaseAggregate<SheetAggregate>
  public interface ISheetAggregateRepo
    {
        Task<SheetAggregate> GetItem(Guid id);
        Task<IEnumerable<SheetAggregate>> GetItems();
        Task<Guid> Add(SheetAggregate item);
        Task Update(SheetAggregate item);
        Task Delete(Guid id);
        Task<Sheet> Approve(Guid sheetId);
    }
}
