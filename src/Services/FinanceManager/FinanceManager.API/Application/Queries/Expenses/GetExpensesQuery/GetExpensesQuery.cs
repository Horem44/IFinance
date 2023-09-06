using FinanceManager.API.Application.Queries.Expenses.Dto;
using MediatR;

namespace FinanceManager.API.Application.Queries.Expenses.GetExpensesQuery
{
    public record GetExpensesQuery() : IRequest<List<ExpenseDto>>;
}
