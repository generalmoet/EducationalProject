using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.Mapping;
using Infrastructure.Persistence.PostgreSQL;

namespace Application.Tests.Common;

public class QueryTestFixture : IDisposable
{
    public UserContext Context;
    public IMapper Mapper;

    public QueryTestFixture()
    {
        Context = UserContextFactory.Create();
        var configProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(typeof(IUserDbContext).Assembly));
        });
        Mapper = configProvider.CreateMapper();
    }
    
    public void Dispose()
    {
        UserContextFactory.Destroy(Context);
    }
    
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}