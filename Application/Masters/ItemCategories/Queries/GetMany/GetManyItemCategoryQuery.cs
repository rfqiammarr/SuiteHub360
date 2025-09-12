using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Commons.Mappings;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Queries;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Queries.GetMany;

public class GetManyItemCategoryQuery : IRequest<ListResponse<GetItemCategoryResponse>>
{
}

public class GetManyItemCategoryMapper : IMapFrom<ItemCategory, GetItemCategoryResponse>
{
}

public class GetManyItemCategoryHandler : IRequestHandler<GetManyItemCategoryQuery, ListResponse<GetItemCategoryResponse>>
{
    private readonly ISuiteHub360DbContext _context;
    private readonly IMapper _mapper;

    public GetManyItemCategoryHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListResponse<GetItemCategoryResponse>> Handle(GetManyItemCategoryQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.ItemCategories
                 .AsNoTracking()
                 .Where(x => x.IsDeleted == false)
                 .ProjectTo<GetItemCategoryResponse>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

        return query.ToListResponse();
    }
}