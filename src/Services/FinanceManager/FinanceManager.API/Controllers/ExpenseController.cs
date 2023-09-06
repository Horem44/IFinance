using FinanceManager.API.Application.Commands.Expenses.AddExpenseCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(
            AddExpenseCommand command,
            CancellationToken cancellationToken
        )
        {
            var expenseId = await _mediator.Send(command, cancellationToken);
            return Ok(expenseId);
        }
    }
}
