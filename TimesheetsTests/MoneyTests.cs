using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.ValueObjects;
using Xunit;

namespace TimesheetsTests
{
    public class MoneyTests
    {

        private decimal amount;
        [Fact]
        public void MoneyTest()
        {
            amount = Random();
            var money=Money.FromDeciaml(amount);
            money.Amount.Should().Be(amount);
        }
        private static decimal Random()
        {
            Random random = new Random();
            decimal randomDecimal = random.Next(0, 100);
            return randomDecimal;
        }
    }
}
