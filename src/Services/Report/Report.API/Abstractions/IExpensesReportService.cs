using Report.API.Entities;

namespace Report.API.Abstractions
{
    public interface IExpensesReportService
    {
        public Task<Guid> AddExpensesReport(ExpensesReport expensesReport);
        public Task<Guid> UpdateExpensesReport(ExpensesReport expensesReport);
        public Task<Guid> DeleteExpensesReport(Guid id);
        public Task<List<ExpensesReport>> GetExpensesReports();
    }
}
