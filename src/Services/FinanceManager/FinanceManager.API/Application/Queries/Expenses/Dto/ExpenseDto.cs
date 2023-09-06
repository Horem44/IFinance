namespace FinanceManager.API.Application.Queries.Expenses.Dto
{
    public record ExpenseDto(
        Guid Id,
        decimal ExpenseAmount,
        DateTime ExpenseDate,
        string ExpenseType
    );
}
