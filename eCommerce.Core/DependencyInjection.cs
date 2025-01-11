using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //TO DO: Add Infrastructure services here IoC container
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
 