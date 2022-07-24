using Core.Domain.Models;
using Infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.Common;

public class UserContextFactory
{
    public static UserContext Create()
    {
        var options = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new UserContext(options);
        context.Database.EnsureCreated();
        context.Users.AddRange(
            new User
                {
                    Id = 1,
                    Birthday = DateTime.Today,
                    Email = "feed@gmail.com",
                    Name = "Alex",
                    Surname = "Purnya"
                },
                new User
                {
                    Id = 2,
                    Birthday = DateTime.Today,
                    Email = "code@gmail.com",
                    Name = "Nikita",
                    Surname = "Great"
                },
                new User
                {
                    Id = 3,
                    Birthday = DateTime.Today,
                    Email = "gamer2k@gmail.com",
                    Name = "Nikita",
                    Surname = "Moen"
                }
            );
        context.SaveChanges();
        return context;
    }

    public static void Destroy(UserContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
