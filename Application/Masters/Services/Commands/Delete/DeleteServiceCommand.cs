using MediatR;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Services.Commands.Delete;

public class DeleteServiceCommand : IRequest
{
    public int ServiceId { get; set; }
}

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
{
    private readonly ISuiteHub360DbContext _context;

    public DeleteServiceCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var service = _context.RoomTypes.Find(request.ServiceId);

            if (service == null)
            {
                throw new NotFoundException($"Not Found {request.ServiceId}");
            }

            service.IsDeleted = true;
            service.DeletedAt = DateTime.UtcNow;
            service.DeletedBy = "Mas Ammar";

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        catch
        {
            throw;
        }
    }
}
