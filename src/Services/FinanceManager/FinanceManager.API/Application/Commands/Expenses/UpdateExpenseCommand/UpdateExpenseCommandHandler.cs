using AutoMapper;
using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using MediatR;

namespace FinanceManager.API.Application.Commands.Expenses.UpdateExpenseCommand
{
    public record UpdateExpenseCommandHandler(IMapper Mapper, IExpenseRepository ExpenseRepository)
        : IRequestHandler<UpdateExpenseCommand, Guid>
    {
        public async Task<Guid> Handle(
            UpdateExpenseCommand request,
            CancellationToken cancellationToken
        )
        {
            var expense = await ExpenseRepository.GetAsync(request.Id, cancellationToken);

            if (expense is null)
            {
                throw new ArgumentNullException(nameof(expense));
            }

            expense.AddExpenseAmount(request.ExpenseAmount);

            ExpenseRepository.Update(expense);

            await ExpenseRepository.UnitOfWork.SaveChangesAsync();

            return expense.Id;
        }
    }
}
