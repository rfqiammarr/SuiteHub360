using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Commands.Update;

public class UpdateRolesCommand : RoleRequest, IRequest<RoleResponse>
{
    public int RoleId { get; set; }
}

public class UpdateRolesCommandValidator : AbstractValidator<UpdateRolesCommand>
{
    public UpdateRolesCommandValidator()
    {
    }
}

public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, RoleResponse>
{
    public readonly ISuiteHub360DbContext _context;

    public UpdateRolesCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<RoleResponse> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _context.Roles
            .Where(x => x.RoleId == request.RoleId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {
                throw new NotImplementedException("Role Not Found");
            }

            query.RoleName = request.RoleName;
            query.ModifiedBy = "Mas Ammar";
            query.Modified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return new RoleResponse()
            {
                RoleId = request.RoleId,
                RoleName = request.RoleName,
            };
        }
        catch (Exception ex)
        {
            throw new NotImplementedException("Error while updating Role", ex);
        }
    }
}
