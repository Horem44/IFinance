using FinanceManager.API.Application.Behaviours;
using FinanceManager.API.Application.Commands.Expenses.AddExpenseCommand;
using FinanceManager.API.Application.Commands.Revenues.AddRevenueCommand;
using FinanceManager.API.Application.Validations;
using FinanceManager.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinanceManagerContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
    cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
});

builder.Services.AddControllers();

builder.Services.AddSingleton<IValidator<AddExpenseCommand>, AddExpenseCommandValidator>();
builder.Services.AddSingleton<IValidator<DeleteRevenueCommand>, AddRevenueCommandValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAppInfrastructure();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
