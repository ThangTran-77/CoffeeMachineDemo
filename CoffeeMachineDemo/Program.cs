using Business.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Swagger document
var swaggerDoc = builder.Configuration.GetSection("SwaggerDoc").Get<OpenApiInfo>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(swaggerDoc.Version, swaggerDoc);
});

builder.Services.AddControllers();

builder.Services.AddSingleton<IBrewCoffeeService, BrewCoffeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // http://localhost:port/swagger/index.html
    app.UseSwagger();
    app.UseSwaggerUI(); // Optional: customize UI here
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();