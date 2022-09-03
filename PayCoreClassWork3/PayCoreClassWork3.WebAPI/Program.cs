using FluentValidation.AspNetCore;
using PayCoreClassWork3.WebAPI.Core.API.Concrete.Extensions;
using PayCoreClassWork3.WebAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNHibernatePosgreSql(builder.Configuration.GetConnectionString("PostgreSqlConnection")) // NHibernate - PostgreSql konfigürasyonu yapýlýr.
                .AddRegisteries() // Gerekli servisler eklenir.
                .ConfigureAutoMapper(); // AutoMapper konfigürasyonu gerçekleþtirilir.

builder.Services.AddControllers()
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<VehicleValidator>()) // Validasyon sýnýflarýnýn entegrasyonu yapýlýr.
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<ContainerValidator>());

builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger().UseSwaggerUI();

app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.Run();