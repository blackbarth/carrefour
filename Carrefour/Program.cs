using Carrefour.Context;
using Carrefour.Data.Implements;
using Carrefour.Data.Interfaces;
using Carrefour.Services.Implements;
using Carrefour.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LancamentoContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();
builder.Services.AddScoped<ILancamentoServico, LancamentoServico>();
builder.Services.AddScoped<IConsolidadoDiarioServico, ConsolidadoDiarioServico>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Lancamento}/{action=Index}/{id?}");

app.Run();
