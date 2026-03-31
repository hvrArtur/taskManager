using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Users.CreateUser;
using TaskManager.Application.Features.Users.DeleteUser;
using TaskManager.Application.Features.Users.GetUser;
using TaskManager.Application.Features.Users.GetUserByNickName;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController(
    ICreateUserCommandHandler createUserCommandHandler,
    IGetUserQueryHandler getUserQueryHandler,
    IGetUserByNickNameQueryHandler getUserByNickNameQueryHandler,
    IDeleteUserCommandHandler deleteUserCommandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(request.NickName, request.FirstName, request.LastName);
        var result = await createUserCommandHandler.HandleAsync(command, cancellationToken);
        return CreatedAtAction(nameof(Get), new { userId = result.Id }, result);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> Get(Guid userId, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(userId);
        var result = await getUserQueryHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("by-nickname/{nickName}")]
    public async Task<IActionResult> GetByNickName(string nickName, CancellationToken cancellationToken)
    {
        var query = new GetUserByNickNameQuery(nickName);
        var result = await getUserByNickNameQueryHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> Delete(Guid userId, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(userId);
        await deleteUserCommandHandler.HandleAsync(command, cancellationToken);
        return NoContent();
    }
}

public sealed record CreateUserRequest(string NickName, string FirstName, string LastName);
