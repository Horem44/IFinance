using FinanceManager.API.Application.Commands.Expenses.AddExpenseCommand;
using FluentValidation;

namespace FinanceManager.API.Application.Validations
{
    public class AddExpenseCommandValidator : AbstractValidator<AddExpenseCommand>
    {
        public AddExpenseCommandValidator()
        {
            RuleFor(expense => expense.ExpenseAmount).NotEmpty();
            RuleFor(expense => expense.IdentityId).NotEmpty();
        }
    }
}
