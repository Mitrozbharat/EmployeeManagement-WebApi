using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }

    }
}
