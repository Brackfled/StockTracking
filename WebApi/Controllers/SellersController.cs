using Application.Features.Brands.Commands.Create;
using Application.Features.Sellers.Commands.Create;
using Application.Features.Sellers.Commands.Delete;
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Queries.GetList;
using Core.Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSellerCommand createSellerCommand)
        {

            CreatedSellerResponse response = await Mediator.Send(createSellerCommand);

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListSellerQuery getListSellerQuery)
        {

            GetListResponse<GetListSellerListItemDto> response = await Mediator.Send(getListSellerQuery);

            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedSellerResponse response = await Mediator.Send(new DeleteSellerCommand { Id = id});
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSellerCommand updateSellerCommand)
        {
            UpdatedSellerResponse response = await Mediator.Send(updateSellerCommand);
            return Ok(response);
        }
    }
}
