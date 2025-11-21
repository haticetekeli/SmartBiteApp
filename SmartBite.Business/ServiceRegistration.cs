using Microsoft.Extensions.DependencyInjection;
using SmartBite.Business.Services.Auth.Abstract;
using SmartBite.Business.Services.Auth.Concrete;

namespace SmartBite.Business
{
    public static class ServiceRegistration
    {
        public static void BusinessRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

        }
    }
}
