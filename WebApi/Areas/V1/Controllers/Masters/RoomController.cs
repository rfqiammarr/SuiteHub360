using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Commands.Create;
using RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Commands.Delete;
using RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Commands.Update;
using RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Queries.GetMany;
using RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Queries.GetOne;
using RifqiAmmarR.SuiteHub360.Shared.Common.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Commands;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Queries;

namespace RifqiAmmarR.SuiteHub360.WebApi.Areas.V1.Controllers.Masters;

[ApiVersion(ApiVersioning.V1.Number)]
public class RoomController : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetRoomResponse>))]
    public async Task<ActionResult<ListResponse<GetRoomResponse>>> GetManyRoom([FromQuery] GetManyRoomQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet(ApiEndPoint.V1.Rooms.RouteTemplateFor.RoomId)]
    [Produces(typeof(GetRoomResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseResult<GetRoomResponse>>> GetOneRoom([FromRoute] int roomId)
    {
        return await Mediator.Send(new GetOneRoomQuery { RoomId = roomId });
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<RoomResponse>> CreateRoom([FromBody] CreateRoomCommand command)
    {
        return CreatedAtAction(nameof(CreateRoom), await Mediator.Send(command));
    }

    [HttpPut(ApiEndPoint.V1.Rooms.RouteTemplateFor.RoomId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<RoomResponse>> UpdateRoom([FromRoute] int roomId, [FromBody] UpdateRoomCommand command)
    {

        if (roomId != command.RoomId)
        {
            return BadRequest("Route RoomId must be same as Body RoomId");
        }

        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete(ApiEndPoint.V1.Rooms.RouteTemplateFor.RoomId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteRoom([FromRoute] int roomId)
    {
        await Mediator.Send(new DeleteRoomCommand { RoomId = roomId });
        return NoContent();
    }
}
