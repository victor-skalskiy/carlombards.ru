using CarLombards.DAL;
using CarLombards.Interfaces;
using CarLombards.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

var useMSSQL = builder.Configuration.GetSection("DbType").Value != "posgre";
var connectionString = builder.Configuration.GetConnectionString(useMSSQL ? "MSSQLConnection" : "DefaultConnection");

builder.Services
    .AddDbContext<PagesContext>(options =>
    {
        if (useMSSQL)
            options
                .UseSqlServer(
                    connectionString,
                    assembly =>
                        assembly.MigrationsAssembly("CarLombards.DAL"));
        else
            options
                .UseNpgsql(
                    connectionString,
                    assebly =>
                        assebly.MigrationsAssembly("CarLombards.DAL"));
    })
    .AddScoped<IPagesService, PagesService>()
    .AddScoped<IUserManagerService, UserManagerService>()
    .AddSingleton<IPagesOptions, PagesOptions>()
    .AddControllersWithViews();

builder.Services
    .AddTransient<IEmailSender, EmailService>()
    .AddDefaultIdentity<IdentityUser>(
    options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.SignIn.RequireConfirmedEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 4;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddUserManager<AspNetUserManager<IdentityUser>>()
    .AddEntityFrameworkStores<PagesContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Pages/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pages}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();