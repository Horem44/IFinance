using AutoMapper;
using FinanceManager.API.Application.Queries.Expenses.Dto;
using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using MediatR;

namespace FinanceManager.API.Application.Queries.Expenses.GetExpensesQuery
{
    public record GetExpensesQueryHandler(IMapper Mapper, IExpenseRepository ExpenseRepository)
        : IRequestHandler<GetExpensesQuery, List<ExpenseDto>>
    {
        public async Task<List<ExpenseDto>> Handle(
            GetExpensesQuery request,
            CancellationToken cancellationToken
        )
        {
            var expenses = await ExpenseRepository.GetAsync(cancellationToken);
            return expenses.Select(Mapper.Map<ExpenseDto>).ToList();
        }
    }
}
