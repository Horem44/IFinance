using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntityConfigurations
{
    public class RevenueTypeEntityConfiguration : IEntityTypeConfiguration<RevenueType>
    {
        public void Configure(EntityTypeBuilder<RevenueType> builder)
        {
            builder.ToTable(nameof(RevenueType).ToLower());

            builder.HasKey(x => x.Id);

            builder.Property(o => o.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();

            builder.Property(o => o.Name).HasMaxLength(200).IsRequired();
        }
    }
}
