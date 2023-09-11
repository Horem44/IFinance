using AutoMapper;
using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using MediatR;

namespace FinanceManager.API.Application.Commands.Expenses.DeleteExpenseCommand
{
    public record DeleteExpenseCommandHandler(IMapper Mapper, IExpenseRepository ExpenseRepository)
        : IRequestHandler<DeleteExpenseCommand, Guid>
    {
        public async Task<Guid> Handle(
            DeleteExpenseCommand request,
            CancellationToken cancellationToken
        )
        {
            var expense = await ExpenseRepository.GetAsync(request.Id, cancellationToken);

            if (expense is null)
            {
                throw new ArgumentNullException(nameof(expense));
            }

            ExpenseRepository.Delete(expense);
            await ExpenseRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return expense.Id;
        }
    }
}
