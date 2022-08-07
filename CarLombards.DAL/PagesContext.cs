using Microsoft.EntityFrameworkCore;

namespace CarLombards.DAL;

public class PagesContext : DbContext
{
    public DbSet<PagesEntity> PagesEntities { get; set; }

    public PagesContext(DbContextOptions<PagesContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}