using MediatR;

namespace FinanceManager.API.Application.Commands.Revenues.DeleteRevenueCommand
{
    public record DeleteRevenueCommand(Guid Id) : IRequest<Guid>;
}
