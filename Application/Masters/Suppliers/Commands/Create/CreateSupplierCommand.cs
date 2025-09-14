using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Suppliers.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Suppliers.Commands.Create;

public class CreateSupplierCommand : SupplierRequest, IRequest<SupplierResponse>
{
}

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(x => x.SupplierName)
          .NotEmpty().WithMessage("Supplier Name is required.")
          .MaximumLength(10).WithMessage("Supplier Name cannot be longer than 10 characters.");
    }
}

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, SupplierResponse>
{
    private readonly ISuiteHub360DbContext _context;

    public CreateSupplierCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }
    public async Task<SupplierResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var supplierExist = await _context.Suppliers.FirstOrDefaultAsync(x => x.SupplierName == request.SupplierName, cancellationToken);
            if (supplierExist is not null)
            {
                throw new BadRequestException("Supplier has already been registered.");
            }

            var supplier = new Supplier()
            {
                SupplierName = request.SupplierName,
                Phone = request.Phone,
                Email = request.Email,
                Address = request.Address,
                CreatedBy = "Mas Ammar"
            };

            await _context.Suppliers.AddAsync(supplier, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new SupplierResponse()
            {
                SupplierId = supplier.SupplierID,
                SupplierName = supplier.SupplierName,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
