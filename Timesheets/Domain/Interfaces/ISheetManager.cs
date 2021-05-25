using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface ISheetManager
    {
        Task<Sheet> GetItem(Guid id);
        Task<IEnumerable<Sheet>> GetItems();
        Task<Guid> Create(Sheet sheet);
        Task Update(Guid id, Sheet sheetRequest);
    }
}
