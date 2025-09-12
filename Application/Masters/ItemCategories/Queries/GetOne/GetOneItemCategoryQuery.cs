using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Common.Responses;
using RifqiAmmarR.SuiteHub360.Shared.Common.Extensions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Queries;


namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Queries.GetOne;

public class GetOneItemCategoryQuery : IRequest<ResponseResult<GetItemCategoryResponse>>
{
    public int ItemCategoryId { get; set; }
}

public class GetOneItemCategoryMapper : IRequest<ResponseResult<GetItemCategoryResponse>>
{
    public int ItemCategoryId { get; set; }
}

public class GetOneItemCategoryHandler : IRequestHandler<GetOneItemCategoryQuery, ResponseResult<GetItemCategoryResponse>>
{
    public readonly ISuiteHub360DbContext _context;
    public readonly IMapper _mapper;

    public GetOneItemCategoryHandler(ISuiteHub360DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponseResult<GetItemCategoryResponse>> Handle(GetOneItemCategoryQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.ItemCategories
            .Where(x => x.CategoryID == request.ItemCategoryId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

        if (query is null)
        {
            throw new NotFoundException("Item Category not found");
        }

        var itemCategoryResult = _mapper.Map<GetItemCategoryResponse>(query);
        return itemCategoryResult.ToResponseResult();
    }
}
