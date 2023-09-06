using AutoMapper;
using FinanceManager.API.Application.Queries.Revenues.Dto;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using MediatR;

namespace FinanceManager.API.Application.Queries.Revenues.GetRevenuesQuery
{
    public record GetRevenuesQueryHandler(IMapper Mapper, IRevenueRepository RevenueRepository)
        : IRequestHandler<GetRevenuesQuery, List<RevenueDto>>
    {
        public async Task<List<RevenueDto>> Handle(
            GetRevenuesQuery request,
            CancellationToken cancellationToken
        )
        {
            var revenues = await RevenueRepository.GetAsync(cancellationToken);
            return revenues.Select(Mapper.Map<RevenueDto>).ToList();
        }
    }
}
