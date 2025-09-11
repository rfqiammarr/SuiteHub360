using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Queries;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;


namespace RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Queries.GetOne;

public class GetOneRoleQuery : IRequest<ResponseResult<GetRoleResponse>>
{
    public int RoleId { get; set; }
}

public class GetOneRoleMapper : IRequest<ResponseResult<GetRoleResponse>>
{
    public int RoleId { get; set; }
}

public class GetOneRoleHandler : IRequestHandler<GetOneRoleQuery, ResponseResult<GetRoleResponse>>
{
    public readonly ISuiteHub360DbContext _context;
    public readonly IMapper _mapper;

    public GetOneRoleHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseResult<GetRoleResponse>> Handle(GetOneRoleQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Roles
            .Where(x => x.RoleId == request.RoleId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

        if (query is null)
        {
            throw new NotFoundException("Role not found");
        }

        var roleResult = _mapper.Map<GetRoleResponse>(query);
        return roleResult.ToResponseResult();
    }
}
