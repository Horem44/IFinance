using AutoMapper;
using FinanceManager.API.Application.Queries.Revenues.Dto;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using MediatR;

namespace FinanceManager.API.Application.Queries.Revenues.GetRevenuesQuery
{
    public record GetRevenueQueryHandler(IMapper Mapper, IRevenueRepository RevenueRepository)
        : IRequestHandler<GetRevenueQuery, List<RevenueDto>>
    {
        public async Task<List<RevenueDto>> Handle(
            GetRevenueQuery request,
            CancellationToken cancellationToken
        )
        {
            var revenues = await RevenueRepository.GetAsync(cancellationToken);
            return revenues.Select(Mapper.Map<RevenueDto>).ToList();
        }
    }
}
