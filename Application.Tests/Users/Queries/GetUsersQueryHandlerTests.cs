using Application.Tests.Common;
using AutoMapper;
using Core.Application.Users.Queries;
using FluentAssertions;
using Infrastructure.Persistence.PostgreSQL;

namespace Application.Tests.Users.Queries;

[Collection("QueryCollection")]
public class GetUsersQueryHandlerTests
{
    private readonly UserContext Context;
    private readonly IMapper Mapper;

    public GetUsersQueryHandlerTests(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }
    
    [Fact]
    public async Task GetUsersQuery_Success()
    {
        //arrange
        var sut = new GetUsersQueryHandler(Context, Mapper);
        var query = new GetUsersQuery();
        
        //act
        var result = await sut.Handle(query);

        //assert
        result.Should().BeOfType<UserListVm>();
        result.Users.Count.Should().Be(3);
    }
}