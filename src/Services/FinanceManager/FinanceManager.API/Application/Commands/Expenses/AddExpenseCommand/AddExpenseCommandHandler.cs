using AutoMapper;
using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using MediatR;

namespace FinanceManager.API.Application.Commands.Expenses.AddExpenseCommand
{
    public record AddExpenseCommandHandler(IMapper Mapper, IExpenseRepository ExpenseRepository)
        : IRequestHandler<AddExpenseCommand, Guid>
    {
        public async Task<Guid> Handle(
            AddExpenseCommand request,
            CancellationToken cancellationToken
        )
        {
            var expense = ExpenseRepository.Add(Mapper.Map<Expense>(request));
            await ExpenseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return expense.Id;
        }
    }
}
