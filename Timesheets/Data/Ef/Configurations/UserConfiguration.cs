using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models;

namespace Timesheets.Data.Ef.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder
                          .HasOne(user => user.RefreshToken)
                          .WithOne(refreshToken => refreshToken.User);
             //      .HasForeignKey("UserId");
           //  .HasForeignKey<RefreshToken>(x => x.UserId);

        }
    }
}