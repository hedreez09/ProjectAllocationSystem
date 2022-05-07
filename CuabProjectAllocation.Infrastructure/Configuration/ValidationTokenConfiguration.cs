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
    public class ValidationTokenConfiguration : IEntityTypeConfiguration<ValidationToken>
    {
        public void Configure(EntityTypeBuilder<ValidationToken> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TokenValue).IsRequired();
            builder.Property(x => x.Email).IsRequired();    
        }
    }
}
