using Application.Tests.Common;
using AutoMapper;
using Core.Application.Exceptions;
using Core.Application.Users.Queries;
using FluentAssertions;
using Infrastructure.Persistence.PostgreSQL;

namespace Application.Tests.Users.Queries;

[Collection("QueryCollection")]
public class GetUserQueryHandlerTests
{
    private readonly UserContext Context;
    private readonly IMapper Mapper;

    public GetUserQueryHandlerTests(QueryTestFixture fixture)
    {
        Context = fixture.Context;
        Mapper = fixture.Mapper;
    }
    
    [Fact]
    public async Task GetUserQuery_Success()
    {
        //arrange
        var sut = new GetUserQueryHandler(Context, Mapper);
        var query = new GetUserQuery()
        {
            Id = 1
        };
        
        //act
        var result = await sut.Handle(query);

        //assert
        result.Should().BeOfType<UserVm>();
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async Task GetUserQuery_NonExistentUser_WaitError()
    {
        //arrange
        var sut = new GetUserQueryHandler(Context, Mapper);
        var query = new GetUserQuery()
        {
            Id = 5
        };
        
        sut.Invoking
            (
                x => x.Handle(query)
            )
            .Should()
            .ThrowAsync<UserNotFoundException>();
    }
}