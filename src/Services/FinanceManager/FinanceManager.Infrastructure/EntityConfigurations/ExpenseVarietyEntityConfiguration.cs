using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntityConfigurations
{
    public class ExpenseVarietyEntityConfiguration : IEntityTypeConfiguration<ExpenseVariety>
    {
        public void Configure(EntityTypeBuilder<ExpenseVariety> builder)
        {
            builder.ToTable(nameof(ExpenseVariety).ToLower());

            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.DomainEvents);

            builder
                .HasMany(x => x.Expenses)
                .WithOne(x => x.ExpenseVariety)
                .HasForeignKey(x => x.Id);

            builder.HasOne(x => x.ExpenseType).WithMany().HasForeignKey("_expenseTypeId");
        }
    }
}
