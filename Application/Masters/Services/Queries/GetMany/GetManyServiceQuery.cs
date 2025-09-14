using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Commons.Mappings;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Queries;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Services.Queries.GetMany;

public class GetManyServiceQuery : IRequest<ListResponse<GetServiceResponse>>
{
}

public class GetManyServiceMapper : IMapFrom<Service, GetServiceResponse>
{
}

public class GetManyServiceHandler : IRequestHandler<GetManyServiceQuery, ListResponse<GetServiceResponse>>
{
    private readonly ISuiteHub360DbContext _context;
    private readonly IMapper _mapper;

    public GetManyServiceHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetServiceResponse>> Handle(GetManyServiceQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Services
                 .AsNoTracking()
                 .Where(x => x.IsDeleted == false)
                 .ProjectTo<GetServiceResponse>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

        return query.ToListResponse();
    }
}