using AutoMapper;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using MediatR;

namespace FinanceManager.API.Application.Commands.Revenues.UpdateRevenueCommand
{
    public record UpdateRevenueCommandHandler(IMapper Mapper, IRevenueRepository RevenueRepository)
        : IRequestHandler<UpdateRevenueCommand, Guid>
    {
        public async Task<Guid> Handle(
            UpdateRevenueCommand request,
            CancellationToken cancellationToken
        )
        {
            var revenue = await RevenueRepository.GetAsync(request.Id, cancellationToken);

            if (revenue is null)
            {
                throw new ArgumentNullException(nameof(revenue));
            }

            revenue.AddRevenueAmount(request.RevenueAmount);

            RevenueRepository.Update(revenue);

            await RevenueRepository.UnitOfWork.SaveChangesAsync();

            return revenue.Id;
        }
    }
}
