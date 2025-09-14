using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Services.Commands.Update;

public class UpdateServiceCommand : ServiceRequest, IRequest<ServiceResponse>
{
}

public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
{
    public UpdateServiceCommandValidator()
    {
    }
}

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, ServiceResponse>
{
    public readonly ISuiteHub360DbContext _context;

    public UpdateServiceCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _context.Services
            .Where(x => x.ServiceID == request.ServiceId && x.IsDeleted != true)
            .FirstOrDefaultAsync(cancellationToken);

            if (query is null)
            {
                throw new NotImplementedException("Service Not Found");
            }

            query.Name = request.ServiceName;
            query.Description = request.Description;
            query.Price = request.Price;

            query.ModifiedBy = "Mas Ammar";
            query.Modified = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return new ServiceResponse()
            {
                ServiceId = query.ServiceID,
                ServiceName = query.Name,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
