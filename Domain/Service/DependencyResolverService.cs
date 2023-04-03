using Microsoft.Extensions.DependencyInjection;

namespace Domain.Service
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            
        }
    }
}
