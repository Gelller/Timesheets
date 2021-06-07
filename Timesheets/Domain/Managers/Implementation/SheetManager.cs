using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Domain.Aggregates.SheetAgrregate;


namespace Timesheets.Domain.Managers.Implementation
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;
        private readonly ISheetAggregateRepo _sheetAggregateRepo;

        public SheetManager(ISheetRepo sheetRepo, ISheetAggregateRepo sheetAggregateRepo)
        {
            _sheetAggregateRepo = sheetAggregateRepo;
            _sheetRepo = sheetRepo;
        }
        public async Task<Sheet> GetItem(Guid id)
        {
            return await _sheetAggregateRepo.GetItem(id);
        }
        public async Task<IEnumerable<Sheet>> GetItems()
        {
            return await _sheetAggregateRepo.GetItems();
        }
        public async Task<Guid> Create(Sheet sheetRequest)
        {
            var sheet = SheetAggregate.CreateFromSheetDto(sheetRequest);
            await _sheetAggregateRepo.Add(sheet);
            return sheet.Id;
        }

        public async Task Approve(Guid sheetId)
        {
            var sheet = await _sheetAggregateRepo.GetItem(sheetId);
            SheetAggregate.ApproveSheet(sheetId, sheet);
            await _sheetAggregateRepo.Update(sheetId, sheet);
        }
        public async Task Update(Guid id, Sheet item)
        {
            await _sheetAggregateRepo.Update(id, item);
        }
        public async Task Delete(Guid id)
        {
            await _sheetAggregateRepo.Delete(id);
        }
      
    }
}
