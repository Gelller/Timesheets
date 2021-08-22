using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Domain.Managers.Implementation;
using Timesheets.Models;

namespace Timesheets.Domain.Aggregates.UserAggregate
{
    public class UserAggregate:User
    {
        private UserAggregate() { }
        public static UserAggregate Create(string username, byte[] passwordHash, string role)
        {
            return new UserAggregate()
            {
                Id = Guid.NewGuid(),
               Username= username,
               PasswordHash= passwordHash,
               Role= role
            };
        }
        public static UserAggregate Update(Guid id, User user)
        {
            return new UserAggregate()
            {
                Id = id,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                Role = user.Role

            };
        }
    }
}
