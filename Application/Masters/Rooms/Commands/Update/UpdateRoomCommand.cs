using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Commands.Update;

public class UpdateRoomCommand : RoomRequest, IRequest<RoomResponse>
{
    public int RoomId { get; set; }
}

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
    }
}

public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, RoomResponse>
{
    public readonly ISuiteHub360DbContext _context;

    public UpdateRoomCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<RoomResponse> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _context.Rooms
            .Where(x => x.RoomID == request.RoomId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {
                throw new NotImplementedException("Room Not Found");
            }

            query.RoomName = request.RoomName;
            query.RoomNumber = request.RoomNumber;
            query.RoomTypeID = request.RoomTypeID;
            query.Floor = request.Floor;
            query.Status = request.Status;
            query.PricePerNight = request.PricePerNight;
            query.Description = request.Description;
            query.UpdatedAt = request.UpdatedAt;
            query.IsBooking = request.IsBooking;
            query.ModifiedBy = "Mas Ammar";
            query.Modified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return new RoomResponse()
            {
                RoomId = query.RoomID,
                RoomName = query.RoomName,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
