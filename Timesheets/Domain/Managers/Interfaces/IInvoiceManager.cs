using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Managers.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Greate(Invoice invoice);
        Task<Invoice> GetItem(Guid id);
        Task<IEnumerable<Invoice>> GetItems();
        Task Update(Guid id, Invoice invoice);
        Task Delete(Guid id);
    }
}
