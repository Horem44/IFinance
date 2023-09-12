using Microsoft.EntityFrameworkCore;
using Report.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

builder.Services.AddDbContext<ReportContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
