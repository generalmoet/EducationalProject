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
        command.Id = 1;
        
        var sut = new DeleteUserCommandHandler(context);
        
        //act
        await sut.Handle(command, CancellationToken.None);
        
        //assert
        context.Users.SingleOrDefault(user => user.Id == command.Id).Should().BeNull();
    }
    
    [Fact]
    public async Task DeleteUserCommandHandler_DeleteNonExistentUser_WaitError()
    {
        // arrange
        var command = new DeleteUserCommand();
        command.Id = 4;
        var sut = new DeleteUserCommandHandler(context);
         
        sut.Invoking
            (
                x => x.Handle(command)
            )
            .Should()
            .ThrowAsync<UserNotFoundException>();
        
    }
}