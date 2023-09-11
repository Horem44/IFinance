using MediatR;

namespace FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand
{
    public record DeleteRevenueCommand(decimal RevenueAmount, string IdentityId) : IRequest<Guid>;
}
