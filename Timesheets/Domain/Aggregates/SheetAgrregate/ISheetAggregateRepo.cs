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
        Task<Sheet> GetItem(Guid id);
        Task<IEnumerable<Sheet>> GetItems();
        Task<Guid> Add(Sheet item);
        Task Update(Guid id, Sheet item);
        Task Delete(Guid id);
        Task<Sheet> Approve(Guid sheetId);
    }
}
