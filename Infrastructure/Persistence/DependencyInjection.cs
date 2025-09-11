using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.DataContext;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseOptions = new DatabaseOptions
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection")
        };

        var migrationsAssembly = typeof(ApplicationDbContext).Assembly.FullName;

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(databaseOptions.ConnectionString, builder =>
            {
                builder.MigrationsAssembly(migrationsAssembly);
                builder.MigrationsHistoryTable("MigrationLogs", nameof(SuiteHub360));
                builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            options.ConfigureWarnings(cw => cw.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
            options.ConfigureWarnings(cw => cw.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
        });

        services.AddScoped<ISuiteHub360DbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
