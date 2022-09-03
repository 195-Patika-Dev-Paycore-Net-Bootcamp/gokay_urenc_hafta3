using FluentValidation.AspNetCore;
using PayCoreClassWork3.WebAPI.Core.API.Concrete.Extensions;
using PayCoreClassWork3.WebAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNHibernatePosgreSql(builder.Configuration.GetConnectionString("PostgreSqlConnection")) // NHibernate - PostgreSql konfig�rasyonu yap�l�r.
                .AddRegisteries() // Gerekli servisler eklenir.
                .ConfigureAutoMapper(); // AutoMapper konfig�rasyonu ger�ekle�tirilir.

builder.Services.AddControllers()
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<VehicleValidator>()) // Validasyon s�n�flar�n�n entegrasyonu yap�l�r.
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<ContainerValidator>());

builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger().UseSwaggerUI();

app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.Run();