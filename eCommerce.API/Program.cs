using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

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

//fluentvalidations
builder.Services.AddFluentValidationAutoValidation();

// add api explorer services
builder.Services.AddEndpointsApiExplorer();

// add swagger generation services to create swagger sepcifications
builder.Services.AddSwaggerGen();

// add cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// builder the web app
var app = builder.Build();

app.UseExceptionHandlingMiddleware();


// routing
app.UseRouting();
app.UseSwagger(); //adds endpoint that can serve the swagger json
app.UseSwaggerUI(); // adds swagger UI (interactive page  to explore and test PI ENDPOINTS
app.UseCors();




// auth
app.UseAuthentication();
app.UseAuthorization();

// controller routes
app.MapControllers();

app.Run();
