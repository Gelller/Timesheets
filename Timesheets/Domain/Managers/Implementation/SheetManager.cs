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
            return await _sheetRepo.GetItem(id);
        }
        public async Task<IEnumerable<Sheet>> GetItems()
        {
            return await _sheetRepo.GetItems();
        }
        public async Task<Guid> Create(Sheet sheetRequest)
        {
            var sheet = SheetAggregate.CreateFromSheetDto(sheetRequest);
            await _sheetRepo.Add(sheet);
            return sheet.Id;
        }

        public async Task Approve(Guid sheetId)
        {
           var sheet = await _sheetAggregateRepo.GetItem(sheetId);
           sheet.ApproveSheet();
           await _sheetAggregateRepo.Update(sheet);
        }
        public async Task Update(Guid id, Sheet sheetDto)
        {

            var sheet = SheetAggregate.CreateFromSheetDto(sheetDto);
            await _sheetAggregateRepo.Update(sheet);
            // sheet.Id = id;
            //  await _sheetRepo.Update(sheet);
        }
        public async Task Delete(Guid id)
        {
            await _sheetRepo.Delete(id);
        }

       
    }
}
