using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;


namespace Timesheets.Domain.Implementation
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
            _sheetRepo = sheetRepo;
        }
        public async Task<Sheet> GetItem(Guid id)
        {
            return await _sheetRepo.GetItem(id);
        }
        public async Task<IEnumerable<Sheet>> GetItems()
        {
            return await _sheetRepo.GetItems();
        }
        public async Task<Guid> Create(Sheet sheet)
        {          
            await _sheetRepo.Add(sheet);
            return sheet.Id;
        }
        public async Task Update(Guid id, Sheet sheet)
        {
            sheet.Id = id;
            await _sheetRepo.Update(sheet);
        }
        public async Task Delete(Guid id)
        {
            await _sheetRepo.Delete(id);
        }
    }
}
