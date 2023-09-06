using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntityConfigurations
{
    public class ExpenseEntityConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable(nameof(Expense).ToLower());

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdentityId).HasMaxLength(200).IsRequired();

            builder.HasIndex(x => x.IdentityId).IsUnique();

            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.ExpenseAmount).IsRequired();

            builder
                .Property<DateTime>(x => x.ExpenseDate)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ExpenseDate")
                .IsRequired();

            builder.HasOne(x => x.ExpenseVariety).WithMany().HasForeignKey("_expenseVarietyId");
        }
    }
}
