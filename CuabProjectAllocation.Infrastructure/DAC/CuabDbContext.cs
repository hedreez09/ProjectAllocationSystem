using CuabProjectAllocation.Infrastructure.Configuration;
using CuabProjectAllocation.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CuabProjectAllocation.Infrastructure.DAC
{
    public class CuabDbContext: DbContext
    {
        public CuabDbContext()
        {
        }

        public CuabDbContext(DbContextOptions<CuabDbContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ProposalEntry> ProposalEntries { get; set; }
        public virtual DbSet<ProposalRequest> ProposalRequests { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<ValidationToken> ValidationTokens { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<EmailLog> EmailLogs { get; set; }
        public virtual DbSet<LoginHistory> LoginHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new LecturerConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ProposalEntriesConfiguration());
            modelBuilder.ApplyConfiguration(new ProposalRequestConfiguration());
            modelBuilder.ApplyConfiguration(new EmailTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ValidationTokenConfiguration());
            modelBuilder.ApplyConfiguration(new EmailLogConfiguration());
            modelBuilder.ApplyConfiguration(new LoginHistoryConfiguration());
        }

    }
}
