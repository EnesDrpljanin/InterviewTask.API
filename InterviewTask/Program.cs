using Asp.Versioning;
using InterviewTask.Api.Modules;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddApiVersioning(e => e.ApiVersionReader = new UrlSegmentApiVersionReader());
services.AddSwaggerGen();
services.AddDbContextModule(configuration);
services.RegisterServicesModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
