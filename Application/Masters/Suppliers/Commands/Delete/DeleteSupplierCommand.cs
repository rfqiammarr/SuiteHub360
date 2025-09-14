using MediatR;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Commands.Delete;

public class DeleteSupplierCommand : IRequest
{
    public int SupplierId { get; set; }
}

public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand>
{
    private readonly ISuiteHub360DbContext _context;

    public DeleteSupplierCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var supplier = _context.Suppliers.Find(request.SupplierId);

            if (supplier == null)
            {
                throw new NotFoundException($"Not Found {request.SupplierId}");
            }

            supplier.IsDeleted = true;
            supplier.DeletedAt = DateTime.UtcNow;
            supplier.DeletedBy = "Mas Ammar";

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        catch
        {
            throw;
        }
    }
}
