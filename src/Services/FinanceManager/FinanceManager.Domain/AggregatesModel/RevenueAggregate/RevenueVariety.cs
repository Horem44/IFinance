using FinanceManager.Domain.SeedWork;

namespace FinanceManager.Domain.AggregatesModel.RevenueAggregate
{
    public class RevenueVariety : Entity
    {
        public RevenueType RevenueType { get; private set; }

        private List<Revenue> _revenues;
        public IEnumerable<Revenue> Revenues => _revenues.AsReadOnly();
    }
}
