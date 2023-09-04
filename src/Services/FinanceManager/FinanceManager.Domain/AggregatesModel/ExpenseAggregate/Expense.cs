using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.ExpenseAggregate
{
    public class Expense : Entity, IAggregateRoot
    {
        public ExpenseVariety ExpenseVariety { get; private set; }

        public decimal ExpenseAmount { get; private set; }

        public DateTime ExpenseDate { get; private set; }

        public string IdentityId { get; private set; }

        public Expense(string identity, ExpenseVariety expenseVariety, decimal expenseAmount)
        {
            IdentityId = !string.IsNullOrWhiteSpace(identity)
                ? identity
                : throw new ArgumentNullException(nameof(identity));

            ExpenseDate = DateTime.UtcNow;

            ExpenseVariety = expenseVariety;

            AddExpenseAmount(expenseAmount);
        }

        public void AddExpenseAmount(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            ExpenseAmount = amount;
        }
    }
}
