using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Aggregates.UserAggregate;
using Xunit;

namespace TimesheetsTests
{
    public class UserAggregateTests
    {
        [Fact]
        public void CreateTest()
        {
            var builder = new UserAggregateBuilder();
            var user = UserAggregate.Create(
                builder.userName,
                builder.passwordHash,
                builder.role);

            user.Should().As<UserAggregate>();
        }
        [Fact]
        public void IncludeUpdateTest()
        {
            var userBuilder = new UserAggregateBuilder();
            var userAggregate = userBuilder.GetRandomUserAggregate();
            var user = UserAggregate.Update(userAggregate.Id, userAggregate);
            userAggregate.Should().BeEquivalentTo(user);
        }
    }
}
