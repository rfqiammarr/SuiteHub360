using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Commands.Update;
using RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Commands.Create;
using RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Commands.Delete;
using RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Queries.GetMany;
using RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Queries.GetOne;
using RifqiAmmarR.SuiteHub360.Shared.Common.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Commands;
using RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Queries;

namespace RifqiAmmarR.SuiteHub360.WebApi.Areas.V1.Controllers.Masters;

[ApiVersion(ApiVersioning.V1.Number)]
public class RoomTypeController : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetRoomTypeResponse>))]
    public async Task<ActionResult<ListResponse<GetRoomTypeResponse>>> GetManyRoomType([FromQuery] GetManyRoomTypeQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet(ApiEndPoint.V1.RoomTypes.RouteTemplateFor.RoomTypeId)]
    [Produces(typeof(GetRoomTypeResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseResult<GetRoomTypeResponse>>> GetOneRoomType([FromRoute] int roomTypeId)
    {
        return await Mediator.Send(new GetOneRoomTypeQuery { RoomTypeId = roomTypeId });
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<RoomTypeResponse>> CreateRoomType([FromBody] CreateRoomTypeCommand command)
    {
        return CreatedAtAction(nameof(CreateRoomType), await Mediator.Send(command));
    }

    [HttpPut(ApiEndPoint.V1.RoomTypes.RouteTemplateFor.RoomTypeId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<RoomTypeResponse>> UpdateRoomType([FromRoute] int roomTypeId, [FromBody] UpdateRoomTypeCommand command)
    {

        if (roomTypeId != command.RoomTypeId)
        {
            return BadRequest("Route RoomTypeId must be same as Body RoomTypeId");
        }

        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete(ApiEndPoint.V1.RoomTypes.RouteTemplateFor.RoomTypeId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteRoomType([FromRoute] int roomTypeId)
    {
        await Mediator.Send(new DeleteRoomTypeCommand { RoomTypeId = roomTypeId });
        return NoContent();
    }
}
