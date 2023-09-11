using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using FinanceManager.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppInfrastructure(this IServiceCollection services)
        {
            return services
                .AddScoped<IExpenseRepository, ExpenseRepository>()
                .AddScoped<IRevenueRepository, RevenueRepository>();
        }
    }
}
