using Microsoft.EntityFrameworkCore;
using Report.API.Abstractions;
using Report.API.Entities;
using System.Linq.Expressions;

namespace Report.API.Infrastructure.Repositories
{
    public class ExpensesReportRepository : IExpensesReportRepository
    {
        private readonly ReportContext _context;

        public ExpensesReportRepository(ReportContext context)
        {
            _context = context;
        }

        public void Add(ExpensesReport entity) => _context.ExpensesReport.Add(entity);

        public void Delete(ExpensesReport expensesReport) =>
            _context.ExpensesReport.Remove(expensesReport);

        public async Task<ExpensesReport?> Get(Guid id) =>
            await _context.ExpensesReport.Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<List<ExpensesReport>> Get() =>
            await _context.ExpensesReport.ToListAsync();

        public async Task<List<ExpensesReport>> Get(
            Expression<Func<ExpensesReport, bool>> predicate
        ) => await _context.ExpensesReport.Where(predicate).ToListAsync();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Update(ExpensesReport entity) => _context.ExpensesReport.Update(entity);
    }
}
