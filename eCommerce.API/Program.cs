using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// add infrastructure service
builder.Services.AddInfrastructure();
builder.Services.AddCore();


// add controllers to the service collection
builder.Services.AddControllers();


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
