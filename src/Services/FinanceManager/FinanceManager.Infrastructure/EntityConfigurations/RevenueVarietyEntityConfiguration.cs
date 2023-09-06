using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infrastructure.EntityConfigurations
{
    public class RevenueVarietyEntityConfiguration : IEntityTypeConfiguration<RevenueVariety>
    {
        public void Configure(EntityTypeBuilder<RevenueVariety> builder)
        {
            builder.ToTable(nameof(RevenueVariety).ToLower());

            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.DomainEvents);

            builder
                .HasMany(x => x.Revenues)
                .WithOne(x => x.RevenueVariety)
                .HasForeignKey(x => x.Id);

            builder.HasOne(x => x.RevenueType).WithMany().HasForeignKey("_revenueTypeId");
        }
    }
}
