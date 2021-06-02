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
using Timesheets.Domain.Aggregates;

namespace Timesheets.Domain.Managers.Implementation
{
    public class InvoiceManager :IInvoiceManager
    {
          private readonly ISheetRepo _sheetRepo;
        private readonly IInvoiceRepo _invoiceRepo;
        //  private const int Rate = 100;
        private readonly IInvoiceAggregateRepo _invoiceAggregateRepo;
        public InvoiceManager( IInvoiceRepo invoiceRepo, ISheetRepo sheetRepo)
        {
            _invoiceRepo = invoiceRepo;
            _sheetRepo = sheetRepo;
          //  _invoiceAggregateRepo = invoiceAggregateRepo;
        }

        public Task<Guid> Add(InvoiceAggregate item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceAggregate> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceAggregate>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SheetAggregate>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Greate(Invoice request)
        {

            var invoice = InvoiceAggregate.Create(request.ContractId, request.DateEnd, request.DateStart);


            //  var sheetsToInclude = await _invoiceAggregateRepo
            //   .GetSheets(request.ContractId, request.DateStart, request.DateEnd);



            var sheetsToInclude = await _sheetRepo.GetItemsForInvoice(request.ContractId, request.DateStart, request.DateEnd);

            invoice.IncludeSheets(sheetsToInclude);
            await _invoiceRepo.Add(invoice);

            return invoice.Id;

            //var invoice = InvoiceAggregate.Create(invoiceDto.ContractId, invoiceDto.DateStart, invoiceDto.DateEnd);

            //var sheetsToInclude = await _invoiceAggregateRepo.GetSheets(invoice.ContractId, invoice.DateStart, invoice.DateEnd);

            //// invoice.Sheets.AddRange(sheets);
            //// invoice.Sum = invoice.Sheets.Sum(x => x.Amount * Rate);       
            //invoice.IncludeSheets(sheetsToInclude);
            //await _invoiceRepo.Add(invoice);

            //return invoice.Id;

        }

        public Task Update(InvoiceAggregate item)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Invoice invoice)
        {
            throw new NotImplementedException();
        }

        Task<Invoice> IInvoiceManager.GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Invoice>> IInvoiceManager.GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
