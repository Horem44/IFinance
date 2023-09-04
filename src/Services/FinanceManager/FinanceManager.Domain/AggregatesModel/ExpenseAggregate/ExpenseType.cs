using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.ExpenseAggregate
{
    public class ExpenseType : Enumeration
    {
        static ExpenseType BadHabbits = new(1, "Bad Habbits");

        static ExpenseType Rent = new(2, "Rent");

        static ExpenseType Entertainments = new(3, "Entertaiments");

        static ExpenseType Groceries = new(4, "Groceries");

        static ExpenseType Other = new(5, "Other");

        public ExpenseType(int id, string name)
            : base(id, name) { }
    }
}
