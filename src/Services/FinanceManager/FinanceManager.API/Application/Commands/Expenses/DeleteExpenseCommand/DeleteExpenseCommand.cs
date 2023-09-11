using MediatR;

namespace FinanceManager.API.Application.Commands.Expenses.DeleteExpenseCommand
{
    public record DeleteExpenseCommand(Guid Id) : IRequest<Guid>;
}
