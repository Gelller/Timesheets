﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    /// <summary> Информация о договоре с клиентом </summary>
    public class Contract
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Sheet> Sheets { get; set; }
    }
}
