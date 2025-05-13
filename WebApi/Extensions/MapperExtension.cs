using AutoMapper;
using Services.Implementations.Mapping;
using WebApi.Mapping.BeastMapping;

namespace WebApi.Extensions;

public static class MapperExtension
{
    public static IServiceCollection InstallMapper(this IServiceCollection service)
    {
        service.AddSingleton<IMapper>(new Mapper(getMapperConfiguration()));
        return service;
    }

    private static MapperConfiguration getMapperConfiguration()
    {
        var config = new MapperConfiguration(c =>
        {
            c.AddProfile<BeastMappingProfile>();
            c.AddProfile<BeastMappigProfile>();
        });
        config.AssertConfigurationIsValid();
        return config;
    }
}