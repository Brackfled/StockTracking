using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Commands.UpdateFromAuth;
using Application.Features.Users.Queries.GetList;
using Core.Application.Request;
using Core.Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommad)
        {
            CreatedUserResponse response = await Mediator.Send(createUserCommad);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeletedUserResponse response = await Mediator.Send(new DeleteUserCommand { Id = id});
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdatedUserResponse response = await Mediator.Send(updateUserCommand);
            return Ok(response);
        }

        [HttpPut("FromAuth")]
        public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateUserFromAuthCommand updateUserFromAuthCommand)
        {
            updateUserFromAuthCommand.Id = getUserIdFromRequest();
            UpdatedUserFromAuthResponse response = await Mediator.Send(updateUserFromAuthCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListUserListItemDto> response = await Mediator.Send(getListUserQuery);
            return Ok(response);
        }

    }
}
