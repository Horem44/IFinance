using FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand;
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
            AddRevenueCommand command,
            CancellationToken cancellationToken
        )
        {
            var revenueId = await _mediator.Send(command, cancellationToken);
            return Ok(revenueId);
        }
    }
}
