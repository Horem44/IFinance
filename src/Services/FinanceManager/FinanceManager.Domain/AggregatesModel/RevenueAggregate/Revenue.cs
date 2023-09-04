using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.RevenueAggregate
{
    public class Revenue : Entity, IAggregateRoot
    {
        public RevenueVariety RevenueVariety { get; private set; }

        public decimal RevenueAmount { get; private set; }

        public DateTime RevenueDate { get; private set; }

        public string IdentityGuid { get; private set; }
    }
}
