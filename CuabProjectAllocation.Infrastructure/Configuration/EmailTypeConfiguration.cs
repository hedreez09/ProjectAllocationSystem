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
    public class EmailTypeConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MailType).HasConversion<string>().IsRequired();
            builder.Property(x => x.Body).IsRequired(); 
            builder.Property(x => x.Subject).IsRequired();
        }
    }

    public class EmailLogConfiguration : IEntityTypeConfiguration<EmailLog>
    {
        public void Configure(EntityTypeBuilder<EmailLog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Body).IsRequired();
            builder.Property(x => x.Subject).IsRequired();
            builder.Property(x => x.Recepient).IsRequired();
        }
    }
}
