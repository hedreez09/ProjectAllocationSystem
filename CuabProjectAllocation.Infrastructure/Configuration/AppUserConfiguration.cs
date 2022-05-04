using CuabProjectAllocation.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserType).HasConversion<string>().IsRequired();
            builder.Property(t => t.AccountStatus).HasConversion<string>().IsRequired();

            builder.Property(t => t.Username).IsRequired().HasMaxLength(250);
            builder.Property(t => t.EmailAddress).IsRequired().HasMaxLength(250);
            builder.Property(t => t.PasswordHash).IsRequired().HasMaxLength(250);
        }
    }
}
