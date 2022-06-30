using Application.Tests.Common;
using Core.Application.Exceptions;
using Core.Application.Users.Commands;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.Users.Commands;

public class UpdateUserCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateUserCommandHandler_ShouldUpdateUser()
    {
        // arrange
        var command = new UpdateUserCommand
        {
            Id = 1,
            Birthday = DateTime.Today,
            Email = "vasyapupkin@gmail.com",
            Name = "Vasya",
            Surname = "Pupkin"
        };
        
        var sut = new UpdateUserCommandHandler(context);
        
        //act
        await sut.Handle(command, CancellationToken.None);
        
        //assert
        context.Users.SingleOrDefault(user => user.Id == command.Id).Should().BeEquivalentTo(command);
    }
    
    [Fact]
    public async Task UpdateUserCommandHandler_UpdateNonExistentUser()
    {
        // arrange
        var command = new UpdateUserCommand
        {
            Id = 5,
            Birthday = DateTime.Today,
            Email = "vasyapupkin@gmail.com",
            Name = "Vasya",
            Surname = "Pupkin"
        };
        
        var sut = new UpdateUserCommandHandler(context);

        sut.Invoking
        (
            x => x.Handle(command)
        )
        .Should()
        .ThrowAsync<UserNotFoundException>();

    }
}