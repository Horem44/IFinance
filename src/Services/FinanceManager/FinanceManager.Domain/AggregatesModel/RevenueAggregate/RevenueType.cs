using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.RevenueAggregate
{
    public class RevenueType : Enumeration
    {
        public RevenueType(int id, string name)
            : base(id, name) { }
    }
}
