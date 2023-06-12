using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TVRS.Domain.Entities;

namespace TVRS.Infrastructure.Data_Context
{
    public class TvrsDbContext : DbContext
    {
        public DbSet<District> Districts { get; set; }
        public DbSet<Domain.Entities.Attachment> Attachments { get; set; }
        public DbSet<InvestigationStatus> InvestigationStatuses { get; set;}
        public DbSet<MainTopic> MainTopics { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<ReportLog> ReportLogs { get; set; }
        public DbSet<Subtopic> Subtopics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ViolationReport> ViolationReports { get; set; }

        public TvrsDbContext(DbContextOptions<TvrsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ReportLog>()
                        .HasKey(r => new { r.ReportId, r.StatusId });
            modelBuilder.Entity<ReportLog>()
                        .Property(r => r.ReportId)
                        .ValueGeneratedNever();
            modelBuilder.Entity<ReportLog>()
                        .Property(r => r.StatusId)
                        .ValueGeneratedNever();
            modelBuilder.Entity<ReportLog>()
                        .HasOne(r => r.InvestigationStatus)
                        .WithMany()
                        .HasForeignKey(r => r.StatusId)
                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReportLog>()
                        .HasOne(r => r.ViolationReport)
                        .WithMany()
                        .HasForeignKey(r => r.ReportId)
                        .OnDelete(DeleteBehavior.NoAction);
        }



    }
}
