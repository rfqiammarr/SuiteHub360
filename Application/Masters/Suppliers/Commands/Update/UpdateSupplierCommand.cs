using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Commands.Update;

public class UpdateSupplierCommand : SupplierRequest, IRequest<SupplierResponse>
{
}

public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
{
    public UpdateSupplierCommandValidator()
    {
    }
}

public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, SupplierResponse>
{
    public readonly ISuiteHub360DbContext _context;

    public UpdateSupplierCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<SupplierResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _context.Suppliers
            .Where(x => x.SupplierID == request.SupplierId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {
                throw new NotImplementedException("Supplier Not Found");
            }

            query.SupplierName = request.SupplierName;
            query.Phone = request.Phone;
            query.Email = request.Email;
            query.Address = request.Address;

            query.ModifiedBy = "Mas Ammar";
            query.Modified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return new SupplierResponse()
            {
                SupplierId = query.SupplierID,
                SupplierName = query.SupplierName,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
