using Microsoft.Extensions.DependencyInjection;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Application.Services;

namespace Oid85.Athletic.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApplicationServices(
        this IServiceCollection services)
    {
        services.AddTransient<IExerciseTemplateService, ExerciseTemplateService>();
        services.AddTransient<ITrainingService, TrainingService>();
    }
}