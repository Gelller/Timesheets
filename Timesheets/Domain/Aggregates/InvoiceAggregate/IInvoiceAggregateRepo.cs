using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates.SheetAgrregate;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.InvoiceAggregate
{
    public interface IInvoiceAggregateRepo
    {
      //  Task<InvoiceAggregate> GetItem(Guid id);
        Task<IEnumerable<Invoice>> GetItems();
      //  Task<Guid> Add(InvoiceAggregate item);
      // Task Update(InvoiceAggregate item);
      //   Task Delete(Guid id);
        Task<IEnumerable<Sheet>> GetSheets(Guid contractId, DateTime dateStart, DateTime dateEnd);
    }
}
