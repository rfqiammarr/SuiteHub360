using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Commons.Mappings;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Queries;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Queries.GetMany;

public class GetManySupplierQuery : IRequest<ListResponse<GetSupplierResponse>>
{
}

public class GetManySupplierMapper : IMapFrom<Service, GetSupplierResponse>
{
}

public class GetManySupplierHandler : IRequestHandler<GetManySupplierQuery, ListResponse<GetSupplierResponse>>
{
    private readonly ISuiteHub360DbContext _context;
    private readonly IMapper _mapper;

    public GetManySupplierHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetSupplierResponse>> Handle(GetManySupplierQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Suppliers
                 .AsNoTracking()
                 .Where(x => x.IsDeleted == false)
                 .ProjectTo<GetSupplierResponse>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

        return query.ToListResponse();
    }
}