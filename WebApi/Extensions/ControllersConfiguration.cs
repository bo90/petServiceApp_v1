using Infrastructure.Repositories.Implementations;
using Services.Abstractions.BeastServices;
using Services.Implementations.Beast;
using Services.Repositories;

namespace WebApi.Extensions;

public static class ControllersConfiguration
{

    public static IServiceCollection InitilizeControllerConfiguration(this IServiceCollection service)
    {
        service
            .initializeService()
            .initializaRepositories();
        return service;
    }
    
    private static IServiceCollection initializeService(this IServiceCollection service)
    {
        service.AddTransient<IBeastService, BeastMongoService>();
        return service;
    }

    private static IServiceCollection initializaRepositories(this IServiceCollection service)
    {
        service.AddTransient<IBeastRepository, BeastRepository>();
        return service;
    }
}