using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Queries;


namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Queries.GetOne;

public class GetOneItemUnitQuery : IRequest<ResponseResult<GetItemUnitResponse>>
{
    public int ItemUnitId { get; set; }
}

public class GetOneItemUnitMapper : IRequest<ResponseResult<GetItemUnitResponse>>
{
    public int ItemUnitId { get; set; }
}

public class GetOneItemUnitHandler : IRequestHandler<GetOneItemUnitQuery, ResponseResult<GetItemUnitResponse>>
{
    public readonly ISuiteHub360DbContext _context;
    public readonly IMapper _mapper;

    public GetOneItemUnitHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseResult<GetItemUnitResponse>> Handle(GetOneItemUnitQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.ItemUnits
            .Where(x => x.UnitID == request.ItemUnitId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

        if (query is null)
        {
            throw new NotFoundException("Unit not found");
        }

        var itemUnitResult = _mapper.Map<GetItemUnitResponse>(query);
        return itemUnitResult.ToResponseResult();
    }
}
