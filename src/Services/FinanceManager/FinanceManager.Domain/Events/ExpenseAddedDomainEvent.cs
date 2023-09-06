using MediatR;

namespace FinanceManager.Domain.Events
{
    public record ExpenseAddedDomainEvent(
        Guid Id,
        Guid ExpenseAmount,
        string IdentityId,
        DateTime ExpenseDate,
        string ExpenseType
    ) : INotification;
}
