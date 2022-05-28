using Microsoft.EntityFrameworkCore;
using Core.Domain.Models;
using Infrastucture.Persistence.PostgreSQL.EntityConfigurations;

namespace Infrastructure.Persistence.PostgreSQL;

public class UserContext : DbContext
{
    public DbSet<User> Persons { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;port=5432;database=TestBase;Username=postgres;password=5gkm40540");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<User>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<User>().Property(p => p.Surname).IsRequired();
        modelBuilder.Entity<User>().Property(p => p.Birthday).IsRequired();
        modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
