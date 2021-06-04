using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Domain.ValueObjects;
using Timesheets.Models;

namespace Timesheets.Data.Ef.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoices");


        }
    }
    
}
