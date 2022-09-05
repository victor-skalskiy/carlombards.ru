using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarLombards.DAL;

public class PagesContext : IdentityDbContext<IdentityUser>
{
    public DbSet<PagesEntity> PagesEntities { get; set; }

    public PagesContext(DbContextOptions<PagesContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}