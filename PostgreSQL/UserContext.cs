using Microsoft.EntityFrameworkCore;
using Core.Domain.Models;
using Infrastucture.Persistence.PostgreSQL.EntityConfigurations;

namespace Infrastructure.Persistence.PostgreSQL;

public class UserContext : DbContext
{
    public DbSet<User> Persons { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

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
