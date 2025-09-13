using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Commons.Mappings;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Queries;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Queries.GetMany;

public class GetManyRoomTypeQuery : IRequest<ListResponse<GetRoomTypeResponse>>
{
}

public class GetManyRoomTypeMapper : IMapFrom<RoomType, GetRoomTypeResponse>
{
}

public class GetManyRoomTypeHandler : IRequestHandler<GetManyRoomTypeQuery, ListResponse<GetRoomTypeResponse>>
{
    private readonly ISuiteHub360DbContext _context;
    private readonly IMapper _mapper;

    public GetManyRoomTypeHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetRoomTypeResponse>> Handle(GetManyRoomTypeQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.RoomTypes
                 .AsNoTracking()
                 .Where(x => x.IsDeleted == false)
                 .ProjectTo<GetRoomTypeResponse>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

        return query.ToListResponse();
    }
}