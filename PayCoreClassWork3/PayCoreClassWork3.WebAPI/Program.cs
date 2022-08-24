using PayCoreClassWork3.WebAPI.Core.API.Concrete.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNHibernatePosgreSql(builder.Configuration.GetConnectionString("PostgreSqlConnection")); // NHibernate - PostgreSql konfigürasyonu yapýlýr.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();