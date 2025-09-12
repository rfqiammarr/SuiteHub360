using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Masters.ItemUnits.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.ItemUnits.Commands.Update;

public class UpdateItemUnitCommand : ItemUnitRequest, IRequest<ItemUnitResponse>
{
    public int ItemUnitId { get; set; }
}

public class UpdateItemUnitCommandValidator : AbstractValidator<UpdateItemUnitCommand>
{
    public UpdateItemUnitCommandValidator()
    {
    }
}

public class UpdateItemUnitCommandHandler : IRequestHandler<UpdateItemUnitCommand, ItemUnitResponse>
{
    public readonly ISuiteHub360DbContext _context;

    public UpdateItemUnitCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<ItemUnitResponse> Handle(UpdateItemUnitCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _context.ItemUnits
            .Where(x => x.UnitID == request.ItemUnitId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {
                throw new NotImplementedException("Item Unit Not Found");
            }

            query.Name = request.ItemUnitName;
            query.ModifiedBy = "Mas Ammar";
            query.Modified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return new ItemUnitResponse()
            {
                ItemUnitId = query.UnitID,
                ItemUnitName = query.Name,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
