namespace FinanceManager.API.Application.Queries.Revenues.Dto
{
    public record RevenueDto(
        Guid Id,
        decimal RevenueAmount,
        DateTime RevenueDate,
        string RevenueType
    );
}
