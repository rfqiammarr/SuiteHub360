using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Commons.Mappings;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Roles.Queries;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Roles.Queries.GetMany;

public class GetManyRoleQuery : IRequest<ListResponse<GetRoleResponse>>
{
}

public class GetManyRoleMapper : IMapFrom<Role, GetRoleResponse>
{
}

public class GetManyRoleHandler : IRequestHandler<GetManyRoleQuery, ListResponse<GetRoleResponse>>
{
    private readonly ISuiteHub360DbContext _context;
    private readonly IMapper _mapper;

    public GetManyRoleHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetRoleResponse>> Handle(GetManyRoleQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Roles
                 .AsNoTracking()
                 .Where(x => x.IsDeleted == false)
                 .ProjectTo<GetRoleResponse>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

        return query.ToListResponse();
    }
}