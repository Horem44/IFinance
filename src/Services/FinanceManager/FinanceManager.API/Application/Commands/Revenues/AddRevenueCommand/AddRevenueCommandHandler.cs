using AutoMapper;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using MediatR;

namespace FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand
{
    public record AddRevenueCommandHandler(IMapper Mapper, IRevenueRepository RevenueRepository)
        : IRequestHandler<AddRevenueCommand, Guid>
    {
        public async Task<Guid> Handle(
            AddRevenueCommand request,
            CancellationToken cancellationToken
        )
        {
            var revenue = RevenueRepository.Add(Mapper.Map<Revenue>(request));
            await RevenueRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return revenue.Id;
        }
    }
}
