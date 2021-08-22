﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates.InvoiceAggregate;

namespace Timesheets.Models
{
    public class Sheet
    {
        /// <summary> Информация о затраченном времени сотрудника </summary>
        public Guid Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public Guid EmployeeId { get; protected set; }
        public Guid ContractId { get; protected set; }
        public Guid ServiceId { get; protected set; }

        public Guid? InvoiceId { get; protected set; }
        public int Amount { get; protected set; }

        public bool IsApproved { get; protected set; }
        public DateTime ApprovedDate { get; protected set; }
      

        public Employee Employee { get; set; }
        public Contract Contract { get; set; }
        public Service Service { get; set; }
        public Invoice Invoice { get; set; }
    }
}
