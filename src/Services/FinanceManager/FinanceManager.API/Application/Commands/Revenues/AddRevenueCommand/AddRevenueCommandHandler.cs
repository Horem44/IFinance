﻿using AutoMapper;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using MediatR;

namespace FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand
{
    public record DeleteRevenueCommandHandler(IMapper Mapper, IRevenueRepository RevenueRepository)
        : IRequestHandler<DeleteRevenueCommand, Guid>
    {
        public async Task<Guid> Handle(
            DeleteRevenueCommand request,
            CancellationToken cancellationToken
        )
        {
            var revenue = RevenueRepository.Add(Mapper.Map<Revenue>(request));
            await RevenueRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return revenue.Id;
        }
    }
}
