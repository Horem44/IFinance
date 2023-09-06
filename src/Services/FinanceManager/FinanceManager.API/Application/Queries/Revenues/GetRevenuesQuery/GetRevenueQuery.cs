using FinanceManager.API.Application.Queries.Revenues.Dto;
using MediatR;

namespace FinanceManager.API.Application.Queries.Revenues.GetRevenuesQuery
{
    public record GetRevenueQuery() : IRequest<List<RevenueDto>>;
}
