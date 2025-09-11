using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Commands.Create;

public class CreateRoleCommand : RoleRequest, IRequest<RoleResponse>
{
}

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.RoleName)
          .NotEmpty().WithMessage("Role Name is required.")
          .MaximumLength(10).WithMessage("Role Name cannot be longer than 10 characters.");
    }
}

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleResponse>
{
    private readonly ISuiteHub360DbContext _context;

    public CreateRoleCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }
    public async Task<RoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var roleExist = await _context.Roles.FirstOrDefaultAsync(x => x.RoleName == request.RoleName, cancellationToken);
            if (roleExist is not null)
            {
                throw new BadRequestException("Role has already been registered.");
            }

            var role = new Role()
            {
                RoleName = request.RoleName,
                CreatedBy = "Mas Ammar"
            };

            await _context.Roles.AddAsync(role, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new RoleResponse()
            {
                RoleName = request.RoleName,
            };
        }
        catch (Exception ex)
        {
            throw new NotImplementedException("Error while creating Role", ex);
        }
    }
}
