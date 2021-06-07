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
        private readonly IInvoiceAggregateRepo _invoiceAggregateRepo;
        public InvoiceManager(IInvoiceAggregateRepo invoiceAggregateRepo, IInvoiceRepo invoiceRepo, ISheetRepo sheetRepo)
        {
            _invoiceRepo = invoiceRepo;
            _sheetRepo = sheetRepo;
            _invoiceAggregateRepo = invoiceAggregateRepo;
        }

        public async Task Delete(Guid id)
        {
            await _invoiceAggregateRepo.Delete(id);
        }

        public async Task<Invoice> GetItem(Guid id)
        {
            return await _invoiceAggregateRepo.GetItem(id);
        }

        public async Task<IEnumerable<Invoice>> GetItems()
        {
            return await _invoiceAggregateRepo.GetItems();
        }

        public async Task<Guid> Greate(Invoice request)
        {

            var invoice = InvoiceAggregate.Create(request.ContractId, request.DateStart, request.DateEnd);
            var sheetsToInclude = await _invoiceAggregateRepo.GetSheets(invoice.ContractId, invoice.DateStart, invoice.DateEnd);

            invoice.IncludeSheets(sheetsToInclude);
            await _invoiceAggregateRepo.Add(invoice);

            return invoice.Id;      
        }
        public async Task Update(Guid id,Invoice invoice)
        {
            await _invoiceAggregateRepo.Update(id, invoice);
        }
    }
}
