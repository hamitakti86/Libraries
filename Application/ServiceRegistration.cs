using Application.Library.Interfaces;
using Application.Library.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ILibraryService, LibraryService>();
        }
    }
}
