using FinanceManager.API.Application.Queries.Revenues.Dto;
using MediatR;

namespace FinanceManager.API.Application.Queries.Revenues.GetRevenuesQuery
{
    public record GetRevenuesQuery() : IRequest<List<RevenueDto>>;
}
