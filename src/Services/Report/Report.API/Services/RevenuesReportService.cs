using Report.API.Abstractions;
using Report.API.Entities;

namespace Report.API.Services
{
    public class RevenuesReportService : IRevenuesReportService
    {
        private readonly IRevenuesReportRepository _revenuesReportRepository;

        public RevenuesReportService(IRevenuesReportRepository revenuesReportRepository)
        {
            _revenuesReportRepository = revenuesReportRepository;
        }

        public async Task<Guid> AddRevenuesReport(RevenuesReport revenuesReport)
        {
            _revenuesReportRepository.Add(revenuesReport);
            await _revenuesReportRepository.SaveChangesAsync();

            return revenuesReport.Id;
        }

        public async Task<Guid> DeleteRevenuesReport(Guid id)
        {
            var revenuesReport = await _revenuesReportRepository.Get(id);

            if (revenuesReport != null)
            {
                _revenuesReportRepository.Delete(revenuesReport);
                await _revenuesReportRepository.SaveChangesAsync();

                return revenuesReport.Id;
            }

            throw new ArgumentNullException(nameof(revenuesReport));
        }

        public async Task<List<RevenuesReport>> GetRevenuesReports()
        {
            return await _revenuesReportRepository.Get();
        }

        public async Task<Guid> UpdateRevenuesReport(RevenuesReport revenuesReport)
        {
            _revenuesReportRepository.Update(revenuesReport);
            await _revenuesReportRepository.SaveChangesAsync();

            return revenuesReport.Id;
        }
    }
}
