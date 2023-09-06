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

        protected Revenue()
        {
            RevenueVariety = new RevenueVariety();
        }

        public Revenue(string IdentityId, RevenueVariety RevenueVariety, decimal RevenueAmount)
        {
            this.IdentityId = !string.IsNullOrWhiteSpace(IdentityId)
                ? IdentityId
                : throw new ArgumentNullException(nameof(IdentityId));

            RevenueDate = DateTime.UtcNow;

            this.RevenueVariety = RevenueVariety;

            AddRevenueAmount(RevenueAmount);
        }

        public void AddRevenueAmount(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            RevenueAmount = amount;
        }
    }
}
