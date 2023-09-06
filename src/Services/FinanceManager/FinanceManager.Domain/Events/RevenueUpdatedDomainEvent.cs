using MediatR;

namespace FinanceManager.Domain.Events
{
    public record RevenueUpdatedDomainEvent(Guid Id, decimal RevenueAmount, string RevenueType)
        : INotification;
}
