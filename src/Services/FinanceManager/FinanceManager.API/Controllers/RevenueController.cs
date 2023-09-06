using FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand;
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
