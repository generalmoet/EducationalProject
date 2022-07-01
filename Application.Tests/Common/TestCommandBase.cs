using Infrastructure.Persistence.PostgreSQL;

namespace Application.Tests.Common;

public abstract class TestCommandBase : IDisposable
{
    protected readonly UserContext Context;

    public TestCommandBase()
    {
        Context = UserContextFactory.Create();
    }

    public void Dispose()
    {
        UserContextFactory.Destroy(Context);
    }
}