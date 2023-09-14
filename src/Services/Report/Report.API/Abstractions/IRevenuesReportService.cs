using Report.API.Entities;

namespace Report.API.Abstractions
{
    public interface IRevenuesReportService
    {
        public Task<Guid> AddRevenuesReport(RevenuesReport revenuesReport);
        public Task<Guid> UpdateRevenuesReport(RevenuesReport revenuesReport);
        public Task<Guid> DeleteRevenuesReport(Guid id);
        public Task<List<RevenuesReport>> GetRevenuesReports();
    }
}
