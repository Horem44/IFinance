using FinanceManager.API.Application.Commands.Expenses.AddExpenseCommand;
using FinanceManager.API.Application.Queries.Expenses.GetExpensesQuery;
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

        [HttpGet]
        public async Task<IActionResult> GetExpenses(CancellationToken cancellationToken)
        {
            var expenses = await _mediator.Send(new GetExpensesQuery(), cancellationToken);
            return new JsonResult(expenses);
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
