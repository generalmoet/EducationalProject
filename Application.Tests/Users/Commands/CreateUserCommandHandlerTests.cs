using Application.Tests.Common;
using Core.Application.Users.Commands;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.Users.Commands;

public class CreateUserCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateUserCommandHandler_ShouldCreateUser()
    {
        // arrange
        var command = new CreateUserCommand
        {
            Birthday = DateTime.Today,
            Email = "vasyapupkin@gmail.com",
            Name = "Vasya",
            Surname = "Pupkin"
        };
        
        var sut = new CreateUserCommandHandler(Context);
        
        //act
        await sut.Handle(command, CancellationToken.None);
        
        //assert
        Context.Users.SingleOrDefault(user => user.Email == command.Email).Should().BeEquivalentTo(command);
    }
}