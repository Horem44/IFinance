using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.API.Entities;

namespace Report.API.Infrastructure.EntityConfigurations
{
    public class RevenuesReportEntityConfiguration : IEntityTypeConfiguration<RevenuesReport>
    {
        public void Configure(EntityTypeBuilder<RevenuesReport> builder)
        {
            builder.ToTable(nameof(RevenuesReport).ToLower());

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Amount).IsRequired();

            builder.Property(r => r.Type).HasMaxLength(200).IsRequired();

            builder.Property(r => r.Date).HasDefaultValue(DateTime.Now);
        }
    }
}
