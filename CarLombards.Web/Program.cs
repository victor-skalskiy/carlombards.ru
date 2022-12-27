using CarLombards.DAL;
using CarLombards.Interfaces;
using CarLombards.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var useMSSQL = builder.Configuration.GetSection("DbType").Value != "posgre";
var connectionString = builder.Configuration.GetConnectionString(useMSSQL ? "MSSQLConnection" : "DefaultConnection");

builder.Services
    .AddDbContext<PagesContext>(options =>
    {
        if (useMSSQL)
            options.UseSqlServer(connectionString);
        else
            options.UseNpgsql(connectionString);
    })
    .AddScoped<IPagesService, PagesService>()
    .AddSingleton<IPagesOptions, PagesOptions>()
    .AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Settings/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Article}/{action=Index}/{id?}");

app.Run();