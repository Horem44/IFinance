using FinanceManager.Domain.SeedWork;
using MediatR;

namespace FinanceManager.Infrastructure
{
    public static class MediatRExtension
    {
        public static async Task DispatchDomainEventsAsync(
            this IMediator mediator,
            FinanceManagerContext ctx
        )
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();

            domainEntities.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
