using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Queries;


namespace RifqiAmmarR.SuiteHub360.Application.Masters.Services.Queries.GetOne;

public class GetOneServiceQuery : IRequest<ResponseResult<GetServiceResponse>>
{
    public int ServiceId { get; set; }
}

public class GetOneServiceMapper : IRequest<ResponseResult<GetServiceResponse>>
{
}

public class GetOneServiceHandler : IRequestHandler<GetOneServiceQuery, ResponseResult<GetServiceResponse>>
{
    public readonly ISuiteHub360DbContext _context;
    public readonly IMapper _mapper;

    public GetOneServiceHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseResult<GetServiceResponse>> Handle(GetOneServiceQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Services
            .AsNoTracking()
            .Where(x => x.ServiceID == request.ServiceId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

        if (query is null)
        {
            throw new NotFoundException("Service not found");
        }

        var serviceResult = _mapper.Map<GetServiceResponse>(query);
        return serviceResult.ToResponseResult();
    }
}
