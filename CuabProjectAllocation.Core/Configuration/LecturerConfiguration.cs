using CuabProjectAllocation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Configuration
{
    public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
    {
        public void Configure(EntityTypeBuilder<Lecturer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StaffId).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(250);
            builder.Property(x => x.CreatedByIp).HasMaxLength(250);
            builder.Property(x => x.CreatedDate).IsRequired();
        }
    }
}
