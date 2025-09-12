using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Commands.Update;

public class UpdateItemCategoryCommand : ItemCategoryRequest, IRequest<ItemCategoryResponse>
{
    public int ItemCategoryId { get; set; }
}

public class UpdateItemCategoryCommandValidator : AbstractValidator<UpdateItemCategoryCommand>
{
    public UpdateItemCategoryCommandValidator()
    {
    }
}

public class UpdateItemCategoryCommandHandler : IRequestHandler<UpdateItemCategoryCommand, ItemCategoryResponse>
{
    public readonly ISuiteHub360DbContext _context;

    public UpdateItemCategoryCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<ItemCategoryResponse> Handle(UpdateItemCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _context.ItemCategories
            .Where(x => x.CategoryID == request.ItemCategoryId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {
                throw new NotImplementedException("ItemCategory Not Found");
            }

            query.Name = request.ItemCategoryName;
            query.ModifiedBy = "Mas Ammar";
            query.Modified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return new ItemCategoryResponse()
            {
                ItemCategoryId = request.ItemCategoryId,
                ItemCategoryName = request.ItemCategoryName,
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
