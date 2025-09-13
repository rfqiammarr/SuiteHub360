using MediatR;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Rooms.Commands.Delete;

public class DeleteRoomCommand : IRequest
{
    public int RoomId { get; set; }
}

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
{
    private readonly ISuiteHub360DbContext _context;

    public DeleteRoomCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var room = _context.Rooms.Find(request.RoomId);

            if (room == null)
            {
                throw new NotFoundException($"Not Found {request.RoomId}");
            }

            room.IsDeleted = true;
            room.DeletedAt = DateTime.UtcNow;
            room.DeletedBy = "Mas Ammar";

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        catch
        {
            throw;
        }
    }
}
