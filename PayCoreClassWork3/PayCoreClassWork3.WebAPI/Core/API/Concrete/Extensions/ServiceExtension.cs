using PayCoreClassWork3.WebAPI.Business.Abstract;
using PayCoreClassWork3.WebAPI.Business.Concrete;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.DataAccess.Concrete;
using System.Reflection;

namespace PayCoreClassWork3.WebAPI.Core.API.Concrete.Extensions
{
    public static class ServiceExtension
    {
        // Sessionlar ve servisler kayıt edilir.
        public static IServiceCollection AddRegisteries(this IServiceCollection services)
        {
            services.AddScoped<IVehicleSession, VehicleSession>()
                    .AddScoped<IContainerSession, ContainerSession>()
                    .AddScoped<IVehicleService, VehicleService>()
                    .AddScoped<IContainerService, ContainerService>();

            return services;
        }

        // AutoMapper konfigüre edilir.
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}