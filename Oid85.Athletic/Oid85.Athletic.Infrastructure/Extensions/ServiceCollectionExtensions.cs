using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Common.KnownConstants;
using Oid85.Athletic.Infrastructure.Interceptors;

namespace Oid85.Athletic.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
                
        services.AddDbContextPool<AthleticContext>((serviceProvider, options) =>
        {
            var updateInterceptor = serviceProvider.GetRequiredService<UpdateAuditableEntitiesInterceptor>();
                
            options
                .UseNpgsql(configuration.GetValue<string>(KnownSettingsKeys.PostgresFinMarketConnectionString)!)
                .AddInterceptors(updateInterceptor);
        });

        services.AddPooledDbContextFactory<AthleticContext>(options =>
            options
                .UseNpgsql(configuration.GetValue<string>(KnownSettingsKeys.PostgresFinMarketConnectionString)!)
                .EnableServiceProviderCaching(false), poolSize: 32);

        services.AddTransient<IExerciseRepository, ExerciseRepository>();
    }

    public static async Task ApplyMigrations(this IHost host)
    {
        var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
        await using var scope = scopeFactory.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetRequiredService<AthleticContext>();
        await context.Database.MigrateAsync();
    }
}