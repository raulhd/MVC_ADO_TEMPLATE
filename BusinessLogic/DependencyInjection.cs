using AutoMapper;
using BusinessLogic.MapperProfiles;
using BusinessLogic.Service;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace BusinessLogic
{
    public static class DependencyInjection
    {
        public static void AddControllerBLs(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();
        }

        public static void AddAutoMappers(this IServiceCollection services)
        {
            AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClientMapperProfiler>();
            });
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
        }

    }
}
