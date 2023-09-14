using Report.API.Abstractions;
using Report.API.Entities;

namespace Report.API.Services
{
    public class ExpensesReportService : IExpensesReportService
    {
        private readonly IExpensesReportRepository _expensesReportRepository;

        public ExpensesReportService(IExpensesReportRepository expensesReportRepository)
        {
            _expensesReportRepository = expensesReportRepository;
        }

        public async Task<Guid> AddExpensesReport(ExpensesReport expensesReport)
        {
            _expensesReportRepository.Add(expensesReport);
            await _expensesReportRepository.SaveChangesAsync();

            return expensesReport.Id;
        }

        public async Task<Guid> DeleteExpensesReport(Guid id)
        {
            var expensesReport = await _expensesReportRepository.Get(id);

            if (expensesReport != null)
            {
                _expensesReportRepository.Delete(expensesReport);
                await _expensesReportRepository.SaveChangesAsync();

                return expensesReport.Id;
            }

            throw new ArgumentNullException(nameof(expensesReport));
        }

        public async Task<List<ExpensesReport>> GetExpensesReports()
        {
            return await _expensesReportRepository.Get();
        }

        public async Task<Guid> UpdateExpensesReport(ExpensesReport expensesReport)
        {
            _expensesReportRepository.Update(expensesReport);
            await _expensesReportRepository.SaveChangesAsync();

            return expensesReport.Id;
        }
    }
}
