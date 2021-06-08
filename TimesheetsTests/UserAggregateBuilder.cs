using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Aggregates.UserAggregate;
using Timesheets.Domain.Managers.Implementation;

namespace TimesheetsTests
{
    public class UserAggregateBuilder
    {
        public string userName = RandomString(10);
        public byte[] passwordHash = UsersManager.GetPasswordHash(RandomString(10));
        public string role = "admin";
        private static Random _random = new Random(Environment.TickCount);
        public UserAggregate GetRandomUserAggregate()
        {
            var userAggregate = UserAggregate.Create(userName, passwordHash, role);
            return userAggregate;
        }


        private static string RandomString(int length)
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }
    }
    
}
