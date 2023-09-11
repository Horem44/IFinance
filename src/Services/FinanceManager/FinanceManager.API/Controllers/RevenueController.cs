using FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand;
using FinanceManager.API.Application.Commands.Revenues.UpdateRevenueCommand;
using FinanceManager.API.Application.Queries.Revenues.GetRevenuesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RevenueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenses(CancellationToken cancellationToken)
        {
            var revenues = await _mediator.Send(new GetRevenuesQuery(), cancellationToken);
            return new JsonResult(revenues);
        }

        [HttpPost]
        public async Task<IActionResult> AddRevenue(
            [FromBody] DeleteRevenueCommand command,
            CancellationToken cancellationToken
        )
        {
            var revenueId = await _mediator.Send(command, cancellationToken);
            return Ok(revenueId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRevenue(
            [FromBody] UpdateRevenueCommand command,
            CancellationToken cancellationToken
        )
        {
            var revenueId = await _mediator.Send(command, cancellationToken);
            return Ok(revenueId);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRevenue(
            [FromBody] DeleteRevenueCommand command,
            CancellationToken cancellationToken
        )
        {
            var revenueId = await _mediator.Send(command, cancellationToken);
            return Ok(revenueId);
        }
    }
}
