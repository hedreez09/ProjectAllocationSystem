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
    public class ProposalRequestConfiguration : IEntityTypeConfiguration<ProposalRequest>
    {
        public void Configure(EntityTypeBuilder<ProposalRequest> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.MatricNumber).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Status).HasMaxLength(50).HasConversion<string>();
            builder.Property(e => e.RequestType).HasMaxLength(50).HasConversion<string>();

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(250);
            builder.Property(x => x.CreatedByIp).HasMaxLength(250);
            builder.Property(x => x.CreatedDate).IsRequired();

            builder.HasMany(x => x.proposalEntries)
                .WithOne()
                .HasForeignKey(e => e.BatchId)
                .OnDelete(DeleteBehavior.ClientCascade);


        }
    }

    public class ProposalEntriesConfiguration : IEntityTypeConfiguration<ProposalEntry>
    {
        public void Configure(EntityTypeBuilder<ProposalEntry> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(5000).IsRequired();
            builder.Property(e => e.FileExtension).HasMaxLength(10);
            builder.Property(e => e.FileLocation).HasMaxLength(255);
            builder.Property(e => e.FileName).HasMaxLength(255);

            builder.Property(e => e.Status).HasMaxLength(50).HasConversion<string>();            

            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(250);
            builder.Property(x => x.CreatedByIp).HasMaxLength(250);
            builder.Property(x => x.CreatedDate).IsRequired();
           
        }
    }
}
