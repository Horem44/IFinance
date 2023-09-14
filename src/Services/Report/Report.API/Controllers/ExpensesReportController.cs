using Microsoft.AspNetCore.Mvc;
using Report.API.Abstractions;
using Report.API.Entities;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesReportController : ControllerBase
    {
        private readonly IExpensesReportService _expensesReportService;

        public ExpensesReportController(IExpensesReportService expensesReportService)
        {
            _expensesReportService = expensesReportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpensesReport()
        {
            var expensesReport = await _expensesReportService.GetExpensesReports();
            return new JsonResult(expensesReport);
        }

        [HttpDelete]
        [Route("{id: guid}")]
        public async Task<IActionResult> DeleteExpensesReport([FromRoute] Guid id)
        {
            var deletedReportId = await _expensesReportService.DeleteExpensesReport(id);
            return Ok(deletedReportId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExpensesReport(
            [FromBody] ExpensesReport expensesReport
        )
        {
            var updatedReportId = await _expensesReportService.UpdateExpensesReport(expensesReport);
            return Ok(updatedReportId);
        }

        [HttpPost]
        public async Task<IActionResult> AddRevenuesReport([FromBody] ExpensesReport expensesReport)
        {
            var addedReportId = await _expensesReportService.AddExpensesReport(expensesReport);
            return Ok(addedReportId);
        }
    }
}
