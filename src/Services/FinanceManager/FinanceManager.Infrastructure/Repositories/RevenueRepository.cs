using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using FinanceManager.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceManager.Infrastructure.Repositories
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly FinanceManagerContext _context;

        public RevenueRepository(FinanceManagerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Revenue Add(Revenue entity) => _context.Revenue.Add(entity).Entity;

        public void Delete(Revenue entity) => _context.Revenue.Remove(entity);

        public async Task<List<Revenue>> GetAsync(
            CancellationToken cancellationToken,
            int skip = 0,
            int take = 0
        ) => await _context.Revenue.Skip(skip).Take(take).ToListAsync(cancellationToken);

        public async Task<List<Revenue>> GetAsync(
            Expression<Func<Revenue, bool>> predicate,
            CancellationToken cancellationToken
        ) => await _context.Revenue.Where(predicate).ToListAsync(cancellationToken);

        public void Update(Revenue entity) => _context.Entry(entity).State = EntityState.Modified;
    }
}
