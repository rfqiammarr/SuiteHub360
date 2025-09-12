using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Commands.Create;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Commands.Delete;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Commands.Update;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Queries.GetMany;
using RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Queries.GetOne;
using RifqiAmmarR.SuiteHub360.Shared.Common.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Commands;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Queries;

namespace RifqiAmmarR.SuiteHub360.WebApi.Areas.V1.Controllers.Masters;

[ApiVersion(ApiVersioning.V1.Number)]
public class ItemCategoryController : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetItemCategoryResponse>))]
    public async Task<ActionResult<ListResponse<GetItemCategoryResponse>>> GetManyItemCategory([FromQuery] GetManyItemCategoryQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet(ApiEndPoint.V1.ItemCategories.RouteTemplateFor.ItemCategoryId)]
    [Produces(typeof(GetItemCategoryResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseResult<GetItemCategoryResponse>>> GetOneItemCategory([FromRoute] int itemCategoryId)
    {
        return await Mediator.Send(new GetOneItemCategoryQuery { ItemCategoryId = itemCategoryId });
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ItemCategoryResponse>> CreateItemCategory([FromBody] CreateItemCategoryCommand command)
    {
        return CreatedAtAction(nameof(CreateItemCategory), await Mediator.Send(command));
    }

    [HttpPut(ApiEndPoint.V1.ItemCategories.RouteTemplateFor.ItemCategoryId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(typeof(ItemCategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ItemCategoryResponse>> UpdateItemCategory([FromRoute] int itemCategoryId, [FromBody] ItemCategoryRequest request)
    {
        //if (itemCategoryId != request.ItemCategoryId)
        //{
        //    return BadRequest("ItemCategoryId in the path and body do not match.");
        //}

        return await Mediator.Send(new UpdateItemCategoryCommand
        {
            ItemCategoryId = itemCategoryId,
            ItemCategoryName = request.ItemCategoryName
        });
    }

    [HttpDelete(ApiEndPoint.V1.ItemCategories.RouteTemplateFor.ItemCategoryId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteItemCategory([FromRoute] int itemCategoryId)
    {
        await Mediator.Send(new DeleteItemCategoryCommand { ItemCategoryId = itemCategoryId });
        return NoContent();
    }
}
