namespace Infrastructure.Persistence.PostgreSQL;

public class DbInitializer
{
    public static void Initialize(UserContext context)
    {
        context.Database.EnsureCreated();
    }
}
