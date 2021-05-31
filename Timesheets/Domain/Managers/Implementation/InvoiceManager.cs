using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Domain.Aggregates.SheetAgrregate;

namespace Timesheets.Domain.Managers.Implementation
{
    public class InvoiceManager : IInvoiceManager
    {
      //  private readonly ISheetRepo _sheetRepo;
        private readonly IInvoiceRepo _invoiceRepo;
        //  private const int Rate = 100;
        private readonly IInvoiceAggregateRepo _invoiceAggregateRepo;
        public InvoiceManager(IInvoiceAggregateRepo invoiceAggregateRepo, ISheetRepo sheetRepo)
        {
            //    _sheetRepo = sheetRepo;
            _invoiceAggregateRepo = invoiceAggregateRepo;
        }

        public async Task<Guid> Greate(Invoice invoiceDto)
        {
            var invoice = InvoiceAggregate.Create(invoiceDto.ContractId, invoiceDto.DateStart, invoiceDto.DateEnd);

            var sheetsToInclude = await _invoiceAggregateRepo.GetSheets(invoice.ContractId, invoice.DateStart, invoice.DateEnd);

            // invoice.Sheets.AddRange(sheets);
            // invoice.Sum = invoice.Sheets.Sum(x => x.Amount * Rate);       
            invoice.IncludeSheets(sheetsToInclude);
            await _invoiceRepo.Add(invoice);

            return invoice.Id;

        }
        public async Task<Invoice> GetItem(Guid id)
        {
            return await _invoiceRepo.GetItem(id);
        }

        public async Task<IEnumerable<Invoice>> GetItems()
        {
            return await _invoiceRepo.GetItems();
        }

        public Task Update(Guid id, Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

       
    }
}
