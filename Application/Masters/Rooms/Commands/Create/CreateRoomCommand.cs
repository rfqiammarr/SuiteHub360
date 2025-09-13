using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Rooms.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Commands.Create;

public class CreateRoomCommand : RoomRequest, IRequest<RoomResponse>
{
}

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(x => x.RoomName)
          .NotEmpty().WithMessage("Room Name is required.")
          .MaximumLength(10).WithMessage("Room Name cannot be longer than 10 characters.");
    }
}

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomResponse>
{
    private readonly ISuiteHub360DbContext _context;

    public CreateRoomCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }
    public async Task<RoomResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var roomExist = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomName == request.RoomName, cancellationToken);
            if (roomExist is not null)
            {
                throw new BadRequestException("Room has already been registered.");
            }

            var room = new Room()
            {
                RoomName = request.RoomName,
                RoomNumber = request.RoomNumber,
                RoomTypeID = request.RoomTypeID,
                Floor = request.Floor,
                Status = request.Status,
                PricePerNight = request.PricePerNight,
                Description = request.Description,
                UpdatedAt = request.UpdatedAt,
                IsBooking = request.IsBooking,
                CreatedBy = "Mas Ammar"
            };


            await _context.Rooms.AddAsync(room, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new RoomResponse()
            {
                RoomName = room.RoomName,
                RoomId = room.RoomID,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
