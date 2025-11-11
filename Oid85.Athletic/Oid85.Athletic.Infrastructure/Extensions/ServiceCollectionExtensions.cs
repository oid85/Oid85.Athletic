using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Common.KnownConstants;
using Oid85.Athletic.Infrastructure.Mapping;
using Oid85.Athletic.Infrastructure.Repositories;

namespace Oid85.Athletic.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {    
        services.AddDbContextPool<AthleticContext>((serviceProvider, options) =>
        {  
            options.UseNpgsql(configuration.GetValue<string>(KnownSettingsKeys.PostgresAthleticConnectionString)!);
        });

        services.AddPooledDbContextFactory<AthleticContext>(options =>
            options
                .UseNpgsql(configuration.GetValue<string>(KnownSettingsKeys.PostgresAthleticConnectionString)!)
                .EnableServiceProviderCaching(false), poolSize: 32);

        services.AddTransient<IExerciseTemplateRepository, ExerciseTemplateRepository>();
        services.AddTransient<IExerciseRepository, ExerciseRepository>();
        services.AddTransient<ITrainingRepository, TrainingRepository>();
        services.AddTransient<IPlanRepository, PlanRepository>();

        var mapsterConfig = new InfrastructureMapsterConfig();
        services.AddSingleton<InfrastructureMapsterConfig>();
    }

    public static async Task ApplyMigrations(this IHost host)
    {
        var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
        await using var scope = scopeFactory.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetRequiredService<AthleticContext>();
        await context.Database.MigrateAsync();
    }
}