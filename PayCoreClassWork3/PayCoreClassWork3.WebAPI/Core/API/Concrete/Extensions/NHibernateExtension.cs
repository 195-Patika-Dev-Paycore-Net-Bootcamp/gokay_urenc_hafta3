﻿using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using PayCoreClassWork3.WebAPI.Business.Abstract;
using PayCoreClassWork3.WebAPI.Business.Concrete;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.DataAccess.Concrete;

namespace PayCoreClassWork3.WebAPI.Core.API.Concrete.Extensions
{
    // NHibernate - PosgreSql konfigürasyonunun oluşabilmesi için ve gerekli kayıtların eklenebilmesi yer alan sınıf.
    public static class NHibernateExtension
    {
        public static IServiceCollection AddNHibernatePosgreSql(this IServiceCollection services, string connectionString)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(NHibernateExtension).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<PostgreSQLDialect>();
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Validate;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });
            configuration.AddMapping(domainMapping);

            var sessionFactory = configuration.BuildSessionFactory();
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddRegisteries(); // Belirtilen kayıtlar sisteme eklenir.

            return services;
        }

        public static IServiceCollection AddRegisteries(this IServiceCollection services)
        {
            // Sessionlar kayıt edilir.
            services.AddScoped<IVehicleSession, VehicleSession>();
            services.AddScoped<IContainerSession, ContainerSession>();

            // Servisler kayıt edilir.
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IContainerService, ContainerService>();

            return services;
        }
    }
}