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
                    Email = "tw1xfeed@gmail.com",
                    Name = "Alexey",
                    Surname = "Puris"
                },
                new User
                {
                    Id = 2,
                    Birthday = DateTime.Today,
                    Email = "nacicode@gmail.com",
                    Name = "Nikita",
                    Surname = "Velikiy"
                },
                new User
                {
                    Id = 3,
                    Birthday = DateTime.Today,
                    Email = "gamer2k@gmail.com",
                    Name = "Nikita",
                    Surname = "Gusev"
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