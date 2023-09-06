using MediatR;

namespace FinanceManager.API.Application.Commands.Expenses.AddExpenseCommand
{
    public record AddExpenseCommand(decimal ExpenseAmount, string IdentityId) : IRequest<Guid>;
}
