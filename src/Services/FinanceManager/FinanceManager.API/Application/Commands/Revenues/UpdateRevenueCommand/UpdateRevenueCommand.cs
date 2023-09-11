using MediatR;

namespace FinanceManager.API.Application.Commands.Revenues.UpdateRevenueCommand
{
    public record UpdateRevenueCommand(Guid Id, decimal RevenueAmount) : IRequest<Guid>;
}
