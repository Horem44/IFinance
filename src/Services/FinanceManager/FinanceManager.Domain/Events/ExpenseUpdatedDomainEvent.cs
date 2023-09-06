using MediatR;

namespace FinanceManager.Domain.Events
{
    public record ExpenseUpdatedDomainEvent(Guid Id, Guid ExpenseAmount, string ExpenseType)
        : INotification;
}
