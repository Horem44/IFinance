using Microsoft.EntityFrameworkCore;
using Report.API.Entities;
using Report.API.Infrastructure.EntityConfigurations;

namespace Report.API.Infrastructure
{
    public class ReportContext : DbContext
    {
        public DbSet<RevenuesReport> RevenuesReport { get; set; }
        public DbSet<ExpensesReport> ExpensesReport { get; set; }

        public ReportContext(DbContextOptions<ReportContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExpensesReportEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RevenuesReportEntityConfiguration());
        }
    }
}
