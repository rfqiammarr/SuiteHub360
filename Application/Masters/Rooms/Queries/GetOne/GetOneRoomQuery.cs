using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Queries;


namespace RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Queries.GetOne;

public class GetOneRoomQuery : IRequest<ResponseResult<GetRoomResponse>>
{
    public int RoomId { get; set; }
}

public class GetOneRoomMapper : IRequest<ResponseResult<GetRoomResponse>>
{
}

public class GetOneRoomHandler : IRequestHandler<GetOneRoomQuery, ResponseResult<GetRoomResponse>>
{
    public readonly ISuiteHub360DbContext _context;
    public readonly IMapper _mapper;

    public GetOneRoomHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseResult<GetRoomResponse>> Handle(GetOneRoomQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Rooms
            .AsNoTracking()
            .Include(x => x.RoomType)
            .Where(x => x.RoomID == request.RoomId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

        if (query is null)
        {
            throw new NotFoundException("Room not found");
        }

        var roomResult = _mapper.Map<GetRoomResponse>(query);
        return roomResult.ToResponseResult();
    }
}
