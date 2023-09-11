using FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand;
using FluentValidation;

namespace FinanceManager.API.Application.Validations
{
    public class AddRevenueCommandValidator : AbstractValidator<DeleteRevenueCommand>
    {
        public AddRevenueCommandValidator()
        {
            RuleFor(revenue => revenue.RevenueAmount).NotEmpty();
            RuleFor(revenue => revenue.IdentityId).NotEmpty();
        }
    }
}
