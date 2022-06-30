using Infrastructure.Persistence.PostgreSQL;

namespace Application.Tests.Common;

public abstract class TestCommandBase : IDisposable
{
    protected readonly UserContext context;

    public TestCommandBase()
    {
        context = UserContextFactory.Create();
    }

    public void Dispose()
    {
        UserContextFactory.Destroy(context);
    }
}