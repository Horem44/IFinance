using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using FinanceManager.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceManager.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinanceManagerContext _context;

        public ExpenseRepository(FinanceManagerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Expense Add(Expense entity) => _context.Expense.Add(entity).Entity;

        public void Delete(Expense entity) => _context.Expense.Remove(entity);

        public async Task<List<Expense>> GetAsync(
            CancellationToken cancellationToken,
            int skip = 0,
            int take = 0
        ) => await _context.Expense.Skip(skip).Take(take).ToListAsync(cancellationToken);

        public async Task<List<Expense>> GetAsync(
            Expression<Func<Expense, bool>> predicate,
            CancellationToken cancellationToken
        ) => await _context.Expense.Where(predicate).ToListAsync(cancellationToken);

        public async Task<Expense?> GetAsync(Guid id, CancellationToken cancellationToken) =>
            await _context.Expense.FirstOrDefaultAsync(cancellationToken);

        public void Update(Expense entity) => _context.Entry(entity).State = EntityState.Modified;
    }
}
