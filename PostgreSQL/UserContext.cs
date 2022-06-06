using Microsoft.EntityFrameworkCore;
using Core.Domain.Models;
using Infrastucture.Persistence.PostgreSQL.EntityConfigurations;
using Core.Application.Interfaces;

namespace Infrastructure.Persistence.PostgreSQL;

public class UserContext : DbContext, IUserDbContext
{
    public DbSet<User> Users { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
