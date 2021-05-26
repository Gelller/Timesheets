using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Greate(Invoice invoice);
    }
}
