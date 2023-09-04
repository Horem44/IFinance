using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.RevenueAggregate
{
    public class RevenueType : Enumeration
    {
        public static RevenueType Salary = new(1, "Salary");

        public static RevenueType GovermentHelp = new(2, "GovermentHelp");

        public static RevenueType Other = new(3, "Other");

        public RevenueType(int id, string name)
            : base(id, name) { }
    }
}
