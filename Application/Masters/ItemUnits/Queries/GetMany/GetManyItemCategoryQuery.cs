using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Commons.Mappings;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Queries;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Queries.GetMany;

public class GetManyItemUnitQuery : IRequest<ListResponse<GetItemUnitResponse>>
{
}

public class GetManyItemUnitMapper : IMapFrom<ItemUnit, GetItemUnitResponse>
{
}

public class GetManyItemUnitHandler : IRequestHandler<GetManyItemUnitQuery, ListResponse<GetItemUnitResponse>>
{
    private readonly ISuiteHub360DbContext _context;
    private readonly IMapper _mapper;

    public GetManyItemUnitHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetItemUnitResponse>> Handle(GetManyItemUnitQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.ItemUnits
                 .AsNoTracking()
                 .Where(x => x.IsDeleted == false)
                 .ProjectTo<GetItemUnitResponse>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

        return query.ToListResponse();
    }
}