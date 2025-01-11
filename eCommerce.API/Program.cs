using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// add infrastructure service
builder.Services.AddInfrastructure();
builder.Services.AddCore();


// add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(
    typeof(ApplicationUserMappingProfile).Assembly
);

// builder the web app
var app = builder.Build();

app.UseExceptionHandlingMiddleware();


// routing
app.UseRouting();


// auth
app.UseAuthentication();
app.UseAuthorization();

// controller routes
app.MapControllers();

app.Run();
