using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RapiPizzaGM.Data;
using RapiPizzaGM.Data.Context;
using RapiPizzaGM.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<RapiPizzaDbContext>();
builder.Services.AddScoped<IRapiPizzaDbContext, RapiPizzaDbContext>();
builder.Services.AddScoped<IClientesServices, ClientesServices>();
builder.Services.AddScoped<IFacturaServices, FacturaServices>();
builder.Services.AddScoped<IPizzaServices, PizzaServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
