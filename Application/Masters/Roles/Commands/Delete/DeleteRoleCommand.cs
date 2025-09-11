using MediatR;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Commands.Delete;

public class DeleteRoleCommand : IRequest
{
    public int RoleId { get; set; }
}

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly ISuiteHub360DbContext _context;

    public DeleteRoleCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var role = _context.Roles.Find(request.RoleId);

            if (role == null)
            {
                throw new NotFoundException($"Not Found {request.RoleId}");
            }

            role.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        catch
        {
            throw new NotImplementedException();
        }
    }
}
