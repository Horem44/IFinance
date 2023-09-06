using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntityConfigurations
{
    public class RevenueEntityConfiguration : IEntityTypeConfiguration<Revenue>
    {
        public void Configure(EntityTypeBuilder<Revenue> builder)
        {
            builder.ToTable(nameof(Revenue).ToLower());

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdentityId).HasMaxLength(200).IsRequired();

            builder.HasIndex(x => x.IdentityId).IsUnique();

            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.RevenueAmount).IsRequired();

            builder
                .Property<DateTime>(x => x.RevenueDate)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("RevenueDate")
                .IsRequired();

            builder.HasOne(x => x.RevenueVariety).WithMany().HasForeignKey("_revenueVarietyId");
        }
    }
}
