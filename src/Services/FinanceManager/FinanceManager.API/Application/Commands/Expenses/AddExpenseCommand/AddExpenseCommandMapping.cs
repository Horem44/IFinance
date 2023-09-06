using AutoMapper;
using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;

namespace FinanceManager.API.Application.Commands.Expenses.AddExpenseCommand
{
    public class AddExpenseCommandMapping : Profile
    {
        public AddExpenseCommandMapping()
        {
            CreateMap<AddExpenseCommand, Expense>()
                .ForMember(x => x.ExpenseAmount, x => x.MapFrom(z => z.ExpenseAmount))
                .ForMember(x => x.IdentityId, x => x.MapFrom(z => z.IdentityId));
        }
    }
}
