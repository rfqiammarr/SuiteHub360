using MediatR;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemCategories.Commands.Delete;

public class DeleteItemCategoryCommand : IRequest
{
    public int ItemCategoryId { get; set; }
}

public class DeleteItemCategoryCommandHandler : IRequestHandler<DeleteItemCategoryCommand>
{
    private readonly ISuiteHub360DbContext _context;

    public DeleteItemCategoryCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteItemCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var itemCategory = _context.ItemCategories.Find(request.ItemCategoryId);

            if (itemCategory == null)
            {
                throw new NotFoundException($"Not Found {request.ItemCategoryId}");
            }

            itemCategory.IsDeleted = true;
            itemCategory.DeletedAt = DateTime.UtcNow;
            itemCategory.DeletedBy = "Mas Ammar";

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        catch
        {
            throw;
        }
    }
}
