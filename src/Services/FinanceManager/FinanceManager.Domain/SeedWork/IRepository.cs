using System.Linq.Expressions;

namespace FinanceManager.Domain.SeedWork
{
    public interface IRepository<T>
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);

        Task<List<T>> GetAsync(int limit = 0, int offset = 0);

        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
    }
}
