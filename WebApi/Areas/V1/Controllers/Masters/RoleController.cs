using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Commands.Create;
using RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Commands.Delete;
using RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Commands.Update;
using RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Queries.GetMany;
using RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Queries.GetOne;
using RifqiAmmarR.SuiteHub360.Shared.Common.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Commands;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Constants;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Queries;

namespace RifqiAmmarR.SuiteHub360.WebApi.Areas.V1.Controllers.Masters;

[ApiVersion(ApiVersioning.V1.Number)]
public class RoleController : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetRoleResponse>))]
    public async Task<ActionResult<ListResponse<GetRoleResponse>>> GetManyRole([FromQuery] GetManyRoleQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet(ApiEndPoint.V1.Roles.RouteTemplateFor.RoleId)]
    [Produces(typeof(GetRoleResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseResult<GetRoleResponse>>> GetOneRole([FromRoute] int RoleId)
    {
        return await Mediator.Send(new GetOneRoleQuery { RoleId = RoleId });
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<RoleResponse>> CreateRole([FromBody] CreateRoleCommand command)
    {
        return CreatedAtAction(nameof(CreateRole), await Mediator.Send(command));
    }

    [HttpPut(ApiEndPoint.V1.Roles.RouteTemplateFor.RoleId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<RoleResponse>> UpdateRole([FromRoute] int RoleId, [FromBody] RoleRequest request)
    {
        return await Mediator.Send(new UpdateRolesCommand { RoleId = RoleId, RoleName = request.RoleName });
    }

    [HttpDelete(ApiEndPoint.V1.Roles.RouteTemplateFor.RoleId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteRole([FromRoute] int RoleId)
    {
        await Mediator.Send(new DeleteRoleCommand { RoleId = RoleId });
        return NoContent();
    }
}
