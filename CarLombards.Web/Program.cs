using CarLombards.DAL;
using CarLombards.Interfaces;
using CarLombards.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PagesContext>(options => { options.UseNpgsql(connectionString); })
    .AddScoped<IPagesService, PagesService>()
    .AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Article}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "article",
//                pattern: "*",
//                defaults: new { controller = "Article", action = "Test" });
//    //endpoints.MapControllerRoute(name: "default",
//    //            pattern: "{controller=Article}/{action=Index}/{id?}");
//});

app.Run();

