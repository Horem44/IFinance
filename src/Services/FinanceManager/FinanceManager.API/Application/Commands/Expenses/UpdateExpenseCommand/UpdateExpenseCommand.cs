using MediatR;

namespace FinanceManager.API.Application.Commands.Expenses.UpdateExpenseCommand
{
    public record UpdateExpenseCommand(Guid Id, decimal ExpenseAmount) : IRequest<Guid>;
}
