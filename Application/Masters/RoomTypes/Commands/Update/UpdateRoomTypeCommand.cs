using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Commands.Update;

public class UpdateRoomTypeCommand : RoomTypeRequest, IRequest<RoomTypeResponse>
{
}

public class UpdateRoomTypeCommandValidator : AbstractValidator<UpdateRoomTypeCommand>
{
    public UpdateRoomTypeCommandValidator()
    {
    }
}

public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, RoomTypeResponse>
{
    public readonly ISuiteHub360DbContext _context;

    public UpdateRoomTypeCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<RoomTypeResponse> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _context.RoomTypes
            .Where(x => x.RoomTypeID == request.RoomTypeId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {
                throw new NotImplementedException("Room Type Not Found");
            }

            query.Name = request.RoomTypeName;
            query.Description = request.Description;
            query.Capacity = request.Capacity;
            query.BasePrice = request.BasePrice;

            query.ModifiedBy = "Mas Ammar";
            query.Modified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return new RoomTypeResponse()
            {
                RoomTypeId = query.RoomTypeID,
                RoomTypeName = query.Name,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
