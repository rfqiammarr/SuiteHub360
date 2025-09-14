using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Commands.Update;
using RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Commands.Create;
using RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Commands.Delete;
using RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Queries.GetMany;
using RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Queries.GetOne;
using RifqiAmmarR.SuiteHub360.Shared.Common.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Commands;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Queries;

namespace RifqiAmmarR.SuiteHub360.WebApi.Areas.V1.Controllers.Masters;

[ApiVersion(ApiVersioning.V1.Number)]
public class SupplierController : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetSupplierResponse>))]
    public async Task<ActionResult<ListResponse<GetSupplierResponse>>> GetManySupplier([FromQuery] GetManySupplierQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet(ApiEndPoint.V1.Suppliers.RouteTemplateFor.SupplierId)]
    [Produces(typeof(GetSupplierResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseResult<GetSupplierResponse>>> GetOneSupplier([FromRoute] int supplierId)
    {
        return await Mediator.Send(new GetOneSupplierQuery { SupplierId = supplierId });
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<SupplierResponse>> CreateSupplier([FromBody] CreateSupplierCommand command)
    {
        return CreatedAtAction(nameof(CreateSupplier), await Mediator.Send(command));
    }

    [HttpPut(ApiEndPoint.V1.Suppliers.RouteTemplateFor.SupplierId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<SupplierResponse>> UpdateSupplier([FromRoute] int supplierId, [FromBody] UpdateSupplierCommand command)
    {

        if (supplierId != command.SupplierId)
        {
            return BadRequest("Route SupplierId must be same as Body SupplierId");
        }

        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete(ApiEndPoint.V1.Suppliers.RouteTemplateFor.SupplierId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteSupplier([FromRoute] int supplierId)
    {
        await Mediator.Send(new DeleteSupplierCommand { SupplierId = supplierId });
        return NoContent();
    }
}
