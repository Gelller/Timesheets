using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Domain.ValueObjects
{
    public sealed class Money:ValueObject
    {   
        public decimal Amount { get;}
        
        private Money() { }
        private Money(decimal amount)
        {
            Amount = amount;
        }
        public static Money FromDeciaml(decimal amount)
        {
            if(amount<0)
            {
                throw new AggregateException("amount cannot be negative");
            }
            return new Money(amount);
        }
    }
}
