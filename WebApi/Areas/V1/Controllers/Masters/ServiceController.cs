using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.SuiteHub360.Application.Masters.Services.Commands.Update;
using RifqiAmmarR.SuiteHub360.Application.Masters.Services.Commands.Create;
using RifqiAmmarR.SuiteHub360.Application.Masters.Services.Commands.Delete;
using RifqiAmmarR.SuiteHub360.Application.Masters.Services.Queries.GetMany;
using RifqiAmmarR.SuiteHub360.Application.Masters.Services.Queries.GetOne;
using RifqiAmmarR.SuiteHub360.Shared.Common.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Commands;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Queries;

namespace RifqiAmmarR.SuiteHub360.WebApi.Areas.V1.Controllers.Masters;

[ApiVersion(ApiVersioning.V1.Number)]
public class ServicesController : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetServiceResponse>))]
    public async Task<ActionResult<ListResponse<GetServiceResponse>>> GetManyService([FromQuery] GetManyServiceQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet(ApiEndPoint.V1.Services.RouteTemplateFor.ServiceId)]
    [Produces(typeof(GetServiceResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseResult<GetServiceResponse>>> GetOneService([FromRoute] int serviceId)
    {
        return await Mediator.Send(new GetOneServiceQuery { ServiceId = serviceId });
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ServiceResponse>> CreateService([FromBody] CreateServiceCommand command)
    {
        return CreatedAtAction(nameof(CreateService), await Mediator.Send(command));
    }

    [HttpPut(ApiEndPoint.V1.Services.RouteTemplateFor.ServiceId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ServiceResponse>> UpdateService([FromRoute] int serviceId, [FromBody] UpdateServiceCommand command)
    {

        if (serviceId != command.ServiceId)
        {
            return BadRequest("Route ServiceId must be same as Body ServiceId");
        }

        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete(ApiEndPoint.V1.Services.RouteTemplateFor.ServiceId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteService([FromRoute] int serviceId)
    {
        await Mediator.Send(new DeleteServiceCommand { ServiceId = serviceId });
        return NoContent();
    }
}
