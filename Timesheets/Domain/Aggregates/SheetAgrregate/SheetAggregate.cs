using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.SheetAgrregate
{
    public class SheetAggregate:Sheet
    {
        private SheetAggregate() { }

        public static SheetAggregate Create(int amount, Guid contractId, 
            DateTime date, Guid employeeId, Guid serviceId)
        {
            return new SheetAggregate()
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                ContractId = contractId,
                Date = date,
                EmployeeId = employeeId,
                ServiceId = serviceId
            };
        }

        public static SheetAggregate CreateFromSheetDto(Sheet sheet)
        {
            return new SheetAggregate()
            {
                Id = Guid.NewGuid(),
                Amount = sheet.Amount,
                ContractId = sheet.ContractId,
                Date = sheet.Date,
                EmployeeId = sheet.EmployeeId,
                ServiceId = sheet.ServiceId
            };
        }
        public void ApproveSheet()
        {
            IsApproved = true;
            ApprovedDate = DateTime.Now;
        }
        public void ChangeEmployee(Guid newEmployeeId)
        {
            EmployeeId = newEmployeeId;
        }
    }
}
