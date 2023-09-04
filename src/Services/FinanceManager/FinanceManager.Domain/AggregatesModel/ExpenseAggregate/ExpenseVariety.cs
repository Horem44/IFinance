using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.ExpenseAggregate
{
    public class ExpenseVariety : Entity
    {
        public ExpenseType ExpenseType { get; private set; }

        private List<Expense> _expenses;
        public IEnumerable<Expense> Expenses => _expenses.AsReadOnly();
    }
}
