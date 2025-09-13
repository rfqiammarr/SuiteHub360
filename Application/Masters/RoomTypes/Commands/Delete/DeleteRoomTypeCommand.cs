using MediatR;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.RoomTypes.Commands.Delete;

public class DeleteRoomTypeCommand : IRequest
{
    public int RoomTypeId { get; set; }
}

public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand>
{
    private readonly ISuiteHub360DbContext _context;

    public DeleteRoomTypeCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var roomType = _context.RoomTypes.Find(request.RoomTypeId);

            if (roomType == null)
            {
                throw new NotFoundException($"Not Found {request.RoomTypeId}");
            }

            roomType.IsDeleted = true;
            roomType.DeletedAt = DateTime.UtcNow;
            roomType.DeletedBy = "Mas Ammar";

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        catch
        {
            throw;
        }
    }
}
