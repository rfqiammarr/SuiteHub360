using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Commons.Mappings;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Queries;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Queries.GetMany;

public class GetManyRoomQuery : IRequest<ListResponse<GetRoomResponse>>
{
}

public class GetManyRoomMapper : IMapFrom<Room, GetRoomResponse>
{
}

public class GetManyRoomHandler : IRequestHandler<GetManyRoomQuery, ListResponse<GetRoomResponse>>
{
    private readonly ISuiteHub360DbContext _context;
    private readonly IMapper _mapper;

    public GetManyRoomHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetRoomResponse>> Handle(GetManyRoomQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Rooms
                 .AsNoTracking()
                 .Include(x => x.RoomType)
                 .Where(x => x.IsDeleted == false)
                 .ProjectTo<GetRoomResponse>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

        return query.ToListResponse();
    }
}