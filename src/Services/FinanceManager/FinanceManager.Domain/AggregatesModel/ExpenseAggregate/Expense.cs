using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.ExpenseAggregate
{
    public class Expense : Entity, IAggregateRoot
    {
        public ExpenseVariety ExpenseVariety { get; private set; }

        public decimal ExpenseAmount { get; private set; }

        public DateTime ExpenseDate { get; private set; }

        public string IdentityGuid { get; private set; }
    }
}
