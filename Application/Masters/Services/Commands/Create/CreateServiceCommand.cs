using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;
using RifqiAmmarR.SuiteHub360.Shared.Common.Exceptions;
using RifqiAmmarR.SuiteHub360.Shared.Masters.Services.Commands;

namespace RifqiAmmarR.SuiteHub360.Application.Masters.Services.Commands.Create;

public class CreateServiceCommand : ServiceRequest, IRequest<ServiceResponse>
{
}

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(x => x.ServiceName)
          .NotEmpty().WithMessage("Service Name is required.")
          .MaximumLength(10).WithMessage("Service Name cannot be longer than 10 characters.");
    }
}

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ServiceResponse>
{
    private readonly ISuiteHub360DbContext _context;

    public CreateServiceCommandHandler(ISuiteHub360DbContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var serviceExist = await _context.Services.FirstOrDefaultAsync(x => x.Name == request.ServiceName, cancellationToken);
            if (serviceExist is not null)
            {
                throw new BadRequestException("Service has already been registered.");
            }

            var service = new Service()
            {
                Name = request.ServiceName,
                Description = request.Description,
                Price = request.Price,
                CreatedBy = "Mas Ammar"
            };

            await _context.Services.AddAsync(service, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ServiceResponse()
            {
                ServiceId = service.ServiceID,
                ServiceName = service.Name,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
