using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.SuiteHub360.Infrastructure.Persistence;

namespace RifqiAmmarR.SuiteHub360.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Persistence
        services.AddPersistenceService(configuration);
        #endregion Persistence

        return services;
    }
}
