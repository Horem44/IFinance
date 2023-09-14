using System.Linq.Expressions;

namespace Report.API.Abstractions
{
    public interface IRepository<T>
    {
        public Task<T?> Get(Guid id);
        public Task<List<T>> Get();
        public Task<List<T>> Get(Expression<Func<T, bool>> predicate);
        public void Delete(T entity);
        public void Update(T entity);
        public void Add(T entity);

        public Task SaveChangesAsync();
    }
}
