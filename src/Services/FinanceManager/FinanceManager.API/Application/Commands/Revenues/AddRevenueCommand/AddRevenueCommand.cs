using MediatR;

namespace FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand
{
    public record AddRevenueCommand(decimal RevenueAmount, string IdentityId) : IRequest<Guid>;
}
