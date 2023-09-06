using AutoMapper;
using FinanceManager.API.Application.Queries.Revenues.Dto;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;

namespace FinanceManager.API.Application.Queries.Revenues.GetRevenuesQuery
{
    public class GetRevenueQueryMapping : Profile
    {
        public GetRevenueQueryMapping()
        {
            CreateMap<Revenue, RevenueDto>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.RevenueAmount, x => x.MapFrom(z => z.RevenueAmount))
                .ForMember(x => x.RevenueDate, x => x.MapFrom(z => z.RevenueDate))
                .ForMember(
                    x => x.RevenueType,
                    x => x.MapFrom(z => z.RevenueVariety.RevenueType.Name)
                );
        }
    }
}
