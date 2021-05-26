using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Data;
using Timesheets.Domain.Interfaces;

namespace Timesheets.Domain.Implementation
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly ISheetRepo _sheetRepo;
        private readonly IInvoiceRepo _invoiceRepo;
        private const int Rate = 100;
        public InvoiceManager(IInvoiceRepo invoiceRepo, ISheetRepo sheetRepo)
        {
            _sheetRepo = sheetRepo;
            _invoiceRepo = invoiceRepo;
        }

        public async Task<Guid> Greate(Invoice invoice)
        {
            var sheets = await _sheetRepo.GetItemsForInvoice(invoice.ContractId, invoice.DateStart, invoice.DateEnd);
            
            invoice.Sheets.AddRange(sheets);
            invoice.Sum = invoice.Sheets.Sum(x => x.Amount * Rate);       
            await _invoiceRepo.Add(invoice);
            return invoice.Id;

        }
    }
}
