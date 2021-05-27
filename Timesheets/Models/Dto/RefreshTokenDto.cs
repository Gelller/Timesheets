using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto
{
    public class RefreshTokenDto
    {
        public Guid UserId { get; set; }
        public string Refresh { get; set; }
    }
}
