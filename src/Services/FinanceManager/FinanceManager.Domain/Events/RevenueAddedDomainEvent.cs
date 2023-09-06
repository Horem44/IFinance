using MediatR;

namespace FinanceManager.Domain.Events
{
    public record RevenueDomainEvent(
        Guid Id,
        decimal RevenueAmount,
        string IdentityId,
        DateTime RevenueDate,
        string RevenueType
    ) : INotification;
}
