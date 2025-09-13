using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.RoomTypes.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Commands.Create;

public class CreateRoomTypeCommand : RoomTypeRequest, IRequest<RoomTypeResponse>
{
}

public class CreateRoomTypeCommandValidator : AbstractValidator<CreateRoomTypeCommand>
{
    public CreateRoomTypeCommandValidator()
    {
        RuleFor(x => x.RoomTypeName)
          .NotEmpty().WithMessage("Room Type Name is required.")
          .MaximumLength(10).WithMessage("Room Type Name cannot be longer than 10 characters.");
    }
}

public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, RoomTypeResponse>
{
    private readonly ISuiteHub360DbContext _context;

    public CreateRoomTypeCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }
    public async Task<RoomTypeResponse> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var roomtTypeExist = await _context.RoomTypes.FirstOrDefaultAsync(x => x.Name == request.RoomTypeName, cancellationToken);
            if (roomtTypeExist is not null)
            {
                throw new BadRequestException("RoomType has already been registered.");
            }

            var roomType = new RoomType()
            {
                Name = request.RoomTypeName,
                Description = request.Description,
                Capacity = request.Capacity,
                BasePrice = request.BasePrice,
                CreatedBy = "Mas Ammar"
            };

            await _context.RoomTypes.AddAsync(roomType, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new RoomTypeResponse()
            {
                RoomTypeId = roomType.RoomTypeID,
                RoomTypeName = roomType.Name,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
