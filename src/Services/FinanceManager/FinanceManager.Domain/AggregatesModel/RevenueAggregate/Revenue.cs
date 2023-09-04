using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.RevenueAggregate
{
    public class Revenue : Entity, IAggregateRoot
    {
        public RevenueVariety RevenueVariety { get; private set; }

        public decimal RevenueAmount { get; private set; }

        public DateTime RevenueDate { get; private set; }

        public string IdentityId { get; private set; }

        public Revenue(string identity, RevenueVariety expenseVariety, decimal expenseAmount)
        {
            IdentityId = !string.IsNullOrWhiteSpace(identity)
                ? identity
                : throw new ArgumentNullException(nameof(identity));

            RevenueDate = DateTime.UtcNow;

            RevenueVariety = expenseVariety;

            AddRevenueAmount(expenseAmount);
        }

        public void AddRevenueAmount(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            RevenueAmount = amount;
        }
    }
}
