using AutoMapper;
using Core.Application.Users.Commands;
using Core.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebUI.Models;

namespace Presentation.WebUI.Controllers;

[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IMapper _mapper;

    public UserController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<UserListVm>> GetAll()
    {
        var query = new GetUsersQuery();

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserVm>> GetUser(int id)
    {
        var query = new GetUserQuery()
        {
            Id = id
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
    {
        var command = _mapper.Map<CreateUserCommand>(createUserDto);
        
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
    {
        var command = _mapper.Map<UpdateUserCommand>(updateUserDto);

        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand()
        {
            Id = id
        };

        await Mediator.Send(command);
        return NoContent();
    }
}
