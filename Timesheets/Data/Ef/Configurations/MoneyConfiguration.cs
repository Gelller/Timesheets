using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Domain.ValueObjects;
using Timesheets.Models;

namespace Timesheets.Data.Ef.Configurations
{
    public class MoneyConfiguration : IEntityTypeConfiguration<Money>
    {
        public void Configure(EntityTypeBuilder<Money> builder)
        {
            builder.ToTable("money");

            //builder
            //.HasNoKey()
            //.ToView("Sum")
            //.Property(v => v.Sum.Amount)
            //.HasColumnName("Sum");
            //  builder

            //   .Property(b => b)
            //     .HasField("Sum")
            //  .UsePropertyAccessMode(PropertyAccessMode.Field);
            //   PropertyAccessMode
            //builder // <--
            //.Property(x=>x.Sum)
            //.HasDefaultValueSql("Sum")
            //base.Co
            //.Property(c => c.)

            // entityTypeBuilder
            //    .Property(b => b.CreatedDateUtc)
            //    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            //base.Configure(entityTypeBuilder);
        }
    }

}
