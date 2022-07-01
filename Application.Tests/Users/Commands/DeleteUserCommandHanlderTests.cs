using Application.Tests.Common;
using Core.Application.Exceptions;
using Core.Application.Users.Commands;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.Users.Commands;

public class DeleteUserCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteUserCommandHandler_ShouldDeleteUser()
    {
        // arrange
        var command = new DeleteUserCommand();
        var sut = new DeleteUserCommandHandler(Context);
        command.Id = 1;

        //act
        await sut.Handle(command, CancellationToken.None);
        
        //assert
        Context.Users.SingleOrDefault(user => user.Id == command.Id).Should().BeNull();
    }
    
    [Fact]
    public async Task DeleteUserCommandHandler_DeleteNonExistentUser_WaitError()
    {
        var command = new DeleteUserCommand();
        var sut = new DeleteUserCommandHandler(Context);
        command.Id = 4;

        sut.Invoking
            (
                x => x.Handle(command)
            )
            .Should()
            .ThrowAsync<UserNotFoundException>();
        
    }
}