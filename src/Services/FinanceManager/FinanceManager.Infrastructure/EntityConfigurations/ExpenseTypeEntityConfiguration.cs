using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntityConfigurations
{
    public class ExpenseTypeEntityConfiguration : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.ToTable(nameof(ExpenseType).ToLower());

            builder.HasKey(x => x.Id);

            builder.Property(o => o.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();

            builder.Property(o => o.Name).HasMaxLength(200).IsRequired();
        }
    }
}
