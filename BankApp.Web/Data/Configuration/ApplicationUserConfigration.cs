using BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Web.Data.Configuration
{
    public class ApplicationUserConfigration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(250);
            builder.HasMany(x => x.Accounts).WithOne(x => x.ApplicationUser).HasForeignKey(x => x.ApplicationUserId);

        }
    }
}
