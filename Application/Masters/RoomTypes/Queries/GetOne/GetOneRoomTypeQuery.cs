using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Queries;


namespace RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Queries.GetOne;

public class GetOneRoomTypeQuery : IRequest<ResponseResult<GetRoomTypeResponse>>
{
    public int RoomTypeId { get; set; }
}

public class GetOneRoomTypeMapper : IRequest<ResponseResult<GetRoomTypeResponse>>
{
}

public class GetOneRoomTypeHandler : IRequestHandler<GetOneRoomTypeQuery, ResponseResult<GetRoomTypeResponse>>
{
    public readonly ISuiteHub360DbContext _context;
    public readonly IMapper _mapper;

    public GetOneRoomTypeHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseResult<GetRoomTypeResponse>> Handle(GetOneRoomTypeQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.RoomTypes
            .AsNoTracking()
            .Where(x => x.RoomTypeID == request.RoomTypeId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

        if (query is null)
        {
            throw new NotFoundException("Room Type not found");
        }

        var roomTypeResult = _mapper.Map<GetRoomTypeResponse>(query);
        return roomTypeResult.ToResponseResult();
    }
}
