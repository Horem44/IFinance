using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using System.Linq.Expressions;

namespace FinanceManager.Domain.SeedWork
{
    public interface IRepository<T>
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        Revenue Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        Task<List<T>> GetAsync(CancellationToken cancellationToken, int skip = 0, int take = 0);

        Task<List<T>> GetAsync(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken
        );
    }
}
