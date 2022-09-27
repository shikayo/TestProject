using DataAccess.Seeds;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DataAccess;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        var autoMigrate = configuration.GetValue<bool>("AutoMigrate");
        if(autoMigrate)
            Database.Migrate();
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UrlSeed());
    }
    public DbSet<Url> Urls { get; set; }
}

