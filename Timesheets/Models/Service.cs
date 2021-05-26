using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Service
    {
        /// <summary> Информация о предоставляемой услуге в рамках контракта </summary>
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sheet> Sheets { get; set; }
    }
}
