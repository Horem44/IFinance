using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.ExpenseAggregate
{
    public class Expense : Entity, IAggregateRoot
    {
        public ExpenseVariety ExpenseVariety { get; private set; }

        public decimal ExpenseAmount { get; private set; }

        public DateTime ExpenseDate { get; private set; }

        public string IdentityId { get; private set; }

        protected Expense()
        {
            ExpenseVariety = new ExpenseVariety();
        }

        public Expense(string IdentityId, ExpenseVariety ExpenseVariety, decimal ExpenseAmount)
        {
            this.IdentityId = !string.IsNullOrWhiteSpace(IdentityId)
                ? IdentityId
                : throw new ArgumentNullException(nameof(IdentityId));

            ExpenseDate = DateTime.UtcNow;

            this.ExpenseVariety = ExpenseVariety;

            AddExpenseAmount(ExpenseAmount);
        }

        public void AddExpenseAmount(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            ExpenseAmount = amount;
        }
    }
}
