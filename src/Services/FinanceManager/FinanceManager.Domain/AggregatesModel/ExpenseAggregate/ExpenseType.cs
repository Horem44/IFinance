using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.ExpenseAggregate
{
    public class ExpenseType : Enumeration
    {
        public ExpenseType(int id, string name)
            : base(id, name) { }
    }
}
