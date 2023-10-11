using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;
using Application.Library.Interfaces;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceRegistration(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ILibraryRepository, LibraryRepository>();
        }
    }
}
