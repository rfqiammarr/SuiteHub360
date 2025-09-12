using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Commands.Create;

public class CreateItemUnitCommand : ItemUnitRequest, IRequest<ItemUnitResponse>
{
}

public class CreateItemUnitCommandValidator : AbstractValidator<CreateItemUnitCommand>
{
    public CreateItemUnitCommandValidator()
    {
        RuleFor(x => x.ItemUnitName)
          .NotEmpty().WithMessage("ItemUnit Name is required.")
          .MaximumLength(10).WithMessage("ItemUnit Name cannot be longer than 10 characters.");
    }
}

public class CreateItemUnitCommandHandler : IRequestHandler<CreateItemUnitCommand, ItemUnitResponse>
{
    private readonly ISuiteHub360DbContext _context;

    public CreateItemUnitCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }
    public async Task<ItemUnitResponse> Handle(CreateItemUnitCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var itemUnitExist = await _context.ItemUnits.FirstOrDefaultAsync(x => x.Name == request.ItemUnitName, cancellationToken);
            if (itemUnitExist is not null)
            {
                throw new BadRequestException("ItemUnit has already been registered.");
            }

            var itemUnit = new ItemUnit()
            {
                Name = request.ItemUnitName,
                CreatedBy = "Mas Ammar"
            };

            await _context.ItemUnits.AddAsync(itemUnit, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ItemUnitResponse()
            {
                ItemUnitId = itemUnit.UnitID,
                ItemUnitName = itemUnit.Name,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
