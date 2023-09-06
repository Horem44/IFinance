using AutoMapper;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;

namespace FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand
{
    public class AddRevenueCommandMapping : Profile
    {
        public AddRevenueCommandMapping()
        {
            CreateMap<AddRevenueCommand, Revenue>()
                .ForMember(x => x.RevenueAmount, x => x.MapFrom(z => z.RevenueAmount))
                .ForMember(x => x.IdentityId, x => x.MapFrom(z => z.IdentityId));
        }
    }
}
