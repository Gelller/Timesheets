using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models;
using Timesheets.Models.Dto.Authentication;


namespace Timesheets.Data.Ef.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {

        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("refreshToken");

            //builder.Property(x => x.Id)
            //    .ValueGeneratedNever()
            //    .HasColumnName("Id");




            //builder
            //              .HasOne(user => user.User)
            //              .WithOne(refreshToken => refreshToken.RefreshToken)
            // //      .HasForeignKey("UserId");
            // .HasForeignKey<RefreshToken>(x => x.UserId);



            //builder.HasKey(x => x.Id);
            //builder.HasOne(x => x.User).WithOne(x => x.RefreshToken)
            //    .HasForeignKey<RefreshToken>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

            // .Entity<RefreshToken>()
            // .HasOptional(e => e.) // Mark EmployeePaymentMethod property optional in EmployeeBank entity
            //  .WithRequired(b => b.EmployeeBank); // mark EmployeeBank property as required in EmployeePaymentMethod entity. Cannot save EmployeePaymentMethod without EmployeeBank

            //  .HasOne(refreshToken => refreshToken.User)
            //  .WithOne(user => user.RefreshToken);
            //  .HasForeignKey<RefreshToken>(p => p.UserId);
        }
    }
}