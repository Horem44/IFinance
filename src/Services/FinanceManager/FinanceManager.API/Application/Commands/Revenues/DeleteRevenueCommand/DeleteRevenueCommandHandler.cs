using AutoMapper;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using MediatR;

namespace FinanceManager.API.Application.Commands.Revenues.DeleteRevenueCommand
{
    public record DeleteRevenueCommandHandler(IMapper Mapper, IRevenueRepository RevenueRepository)
        : IRequestHandler<DeleteRevenueCommand, Guid>
    {
        public async Task<Guid> Handle(
            DeleteRevenueCommand request,
            CancellationToken cancellationToken
        )
        {
            var revenue = await RevenueRepository.GetAsync(request.Id, cancellationToken);

            if (revenue is null)
            {
                throw new ArgumentNullException(nameof(revenue));
            }

            RevenueRepository.Delete(revenue);
            await RevenueRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return revenue.Id;
        }
    }
}
