using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Queries.GetMany;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Commands.Create;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Commands.Delete;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Commands.Update;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Queries.GetOne;
using RifqiAmmarR.SuiteHub360.Shared.Common.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Queries;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Commands;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Constants;

namespace RifqiAmmarR.SuiteHub360.WebApi.Areas.V1.Controllers.Masters;

[ApiVersion(ApiVersioning.V1.Number)]
public class ItemUnitController : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetItemUnitResponse>))]
    public async Task<ActionResult<ListResponse<GetItemUnitResponse>>> GetManyUnits([FromQuery] GetManyItemUnitQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet(ApiEndPoint.V1.ItemUnits.RouteTemplateFor.ItemUnitId)]
    [Produces(typeof(GetItemUnitResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseResult<GetItemUnitResponse>>> GetOneItemUnit([FromRoute] int itemUnitId)
    {
        return await Mediator.Send(new GetOneItemUnitQuery { ItemUnitId = itemUnitId });
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ItemUnitResponse>> CreateItemUnit([FromBody] CreateItemUnitCommand command)
    {
        return CreatedAtAction(nameof(CreateItemUnit), await Mediator.Send(command));
    }

    [HttpPut(ApiEndPoint.V1.ItemUnits.RouteTemplateFor.ItemUnitId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ItemUnitResponse>> UpdateItemUnit([FromRoute] int itemUnitId, [FromBody] ItemUnitRequest request)
    {
        return await Mediator.Send(new UpdateItemUnitCommand { ItemUnitId = itemUnitId, ItemUnitName = request.ItemUnitName });
    }

    [HttpDelete(ApiEndPoint.V1.ItemUnits.RouteTemplateFor.ItemUnitId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteItemUnit([FromRoute] int itemUnitId)
    {
        await Mediator.Send(new DeleteItemUnitCommand { ItemUnitsId = itemUnitId });
        return NoContent();
    }
}
