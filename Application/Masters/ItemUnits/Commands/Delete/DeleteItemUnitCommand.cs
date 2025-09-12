using MediatR;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Commands.Delete;

public class DeleteItemUnitCommand : IRequest
{
    public int ItemUnitsId { get; set; }
}

public class DeleteItemUnitCommandHandler : IRequestHandler<DeleteItemUnitCommand>
{
    private readonly ISuiteHub360DbContext _context;

    public DeleteItemUnitCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteItemUnitCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var itemUnit = _context.ItemUnits.Find(request.ItemUnitsId);

            if (itemUnit == null)
            {
                throw new NotFoundException($"Not Found {request.ItemUnitsId}");
            }

            itemUnit.IsDeleted = true;
            itemUnit.DeletedAt = DateTime.UtcNow;
            itemUnit.DeletedBy = "Mas Ammar";

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        catch
        {
            throw;
        }
    }
}
