using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto.Authentication
{
    public class RefreshToken
    {
    
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }


    }
}
