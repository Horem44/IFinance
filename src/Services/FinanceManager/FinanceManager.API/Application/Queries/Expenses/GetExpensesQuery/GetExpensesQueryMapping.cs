using AutoMapper;
using FinanceManager.API.Application.Queries.Expenses.Dto;
using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;

namespace FinanceManager.API.Application.Queries.Expenses.GetExpensesQuery
{
    public class GetExpensesQueryMapping : Profile
    {
        public GetExpensesQueryMapping()
        {
            CreateMap<Expense, ExpenseDto>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.ExpenseAmount, x => x.MapFrom(z => z.ExpenseAmount))
                .ForMember(x => x.ExpenseDate, x => x.MapFrom(z => z.ExpenseDate))
                .ForMember(
                    x => x.ExpenseType,
                    x => x.MapFrom(z => z.ExpenseVariety.ExpenseType.Name)
                );
        }
    }
}
