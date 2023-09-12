using Microsoft.EntityFrameworkCore;

namespace Report.API.Infrastructure
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options)
            : base(options) { }
    }
}
