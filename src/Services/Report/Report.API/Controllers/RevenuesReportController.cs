using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Report.API.Abstractions;
using Report.API.Entities;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenuesReportController : ControllerBase
    {
        private readonly IRevenuesReportService _revenuesReportService;

        public RevenuesReportController(IRevenuesReportService revenuesReportService)
        {
            _revenuesReportService = revenuesReportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRevenuesReport()
        {
            var revenuesReports = await _revenuesReportService.GetRevenuesReports();
            return new JsonResult(revenuesReports);
        }

        [HttpDelete]
        [Route("{id: guid}")]
        public async Task<IActionResult> DeleteRevenuesReport([FromRoute] Guid id)
        {
            var deletedReportId = await _revenuesReportService.DeleteRevenuesReport(id);
            return Ok(deletedReportId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRevenuesReport(
            [FromBody] RevenuesReport revenuesReport
        )
        {
            var updatedReportId = await _revenuesReportService.UpdateRevenuesReport(revenuesReport);
            return Ok(updatedReportId);
        }

        [HttpPost]
        public async Task<IActionResult> AddRevenuesReport([FromBody] RevenuesReport revenuesReport)
        {
            var addedReportId = await _revenuesReportService.AddRevenuesReport(revenuesReport);
            return Ok(addedReportId);
        }
    }
}
