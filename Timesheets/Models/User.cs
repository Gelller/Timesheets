using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Models
{
    /// <summary> Информация о пользователе системы </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
