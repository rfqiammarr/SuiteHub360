using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Queries;


namespace RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Queries.GetOne;

public class GetOneSupplierQuery : IRequest<ResponseResult<GetSupplierResponse>>
{
    public int SupplierId { get; set; }
}

public class GetOneSupplierMapper : IRequest<ResponseResult<GetSupplierResponse>>
{
}

public class GetOneSupplierHandler : IRequestHandler<GetOneSupplierQuery, ResponseResult<GetSupplierResponse>>
{
    public readonly ISuiteHub360DbContext _context;
    public readonly IMapper _mapper;

    public GetOneSupplierHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseResult<GetSupplierResponse>> Handle(GetOneSupplierQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.Suppliers
            .AsNoTracking()
            .Where(x => x.SupplierID == request.SupplierId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

        if (query is null)
        {
            throw new NotFoundException("Supplier not found");
        }

        var supplierResult = _mapper.Map<GetSupplierResponse>(query);
        return supplierResult.ToResponseResult();
    }
}
