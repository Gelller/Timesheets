using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto
{
    public class EmployeeDto
    {
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Sheet> Sheets { get; set; }
    }
}
