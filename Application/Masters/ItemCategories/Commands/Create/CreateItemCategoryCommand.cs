using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemCategories.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Commands.Create;

public class CreateItemCategoryCommand : ItemCategoryRequest, IRequest<ItemCategoryResponse>
{
}

public class CreateItemCategoryCommandValidator : AbstractValidator<CreateItemCategoryCommand>
{
    public CreateItemCategoryCommandValidator()
    {
        RuleFor(x => x.ItemCategoryName)
          .NotEmpty().WithMessage("Item Category Name is required.")
          .MaximumLength(10).WithMessage("Item Category Name cannot be longer than 10 characters.");
    }
}

public class CreateItemCategoryCommandHandler : IRequestHandler<CreateItemCategoryCommand, ItemCategoryResponse>
{
    private readonly ISuiteHub360DbContext _context;

    public CreateItemCategoryCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }
    public async Task<ItemCategoryResponse> Handle(CreateItemCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var itemCategoryExist = await _context.ItemCategories.FirstOrDefaultAsync(x => x.Name == request.ItemCategoryName, cancellationToken);
            if (itemCategoryExist is not null)
            {
                throw new BadRequestException("Item Category has already been registered.");
            }

            var itemCategory = new ItemCategory()
            {
                Name = request.ItemCategoryName,
                CreatedBy = "Mas Ammar"
            };

            await _context.ItemCategories.AddAsync(itemCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ItemCategoryResponse()
            {
                ItemCategoryName = request.ItemCategoryName,
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
