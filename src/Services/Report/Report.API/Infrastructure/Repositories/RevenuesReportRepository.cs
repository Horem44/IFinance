using Microsoft.EntityFrameworkCore;
using Report.API.Abstractions;
using Report.API.Entities;
using System.Linq.Expressions;

namespace Report.API.Infrastructure.Repositories
{
    public class RevenuesReportRepository : IRepository<RevenuesReport>
    {
        private readonly ReportContext _context;

        public RevenuesReportRepository(ReportContext context)
        {
            _context = context;
        }

        public void Add(RevenuesReport entity) => _context.RevenuesReport.Add(entity);

        public void Delete(RevenuesReport revenuesReport) =>
            _context.RevenuesReport.Remove(revenuesReport);

        public async Task<RevenuesReport?> Get(Guid id) =>
            await _context.RevenuesReport.Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<List<RevenuesReport>> Get() =>
            await _context.RevenuesReport.ToListAsync();

        public async Task<List<RevenuesReport>> Get(
            Expression<Func<RevenuesReport, bool>> predicate
        ) => await _context.RevenuesReport.Where(predicate).ToListAsync();

        public void Update(RevenuesReport entity) => _context.RevenuesReport.Update(entity);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
