using Ef_Core_Multi_Tenancy.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ef_Core_Multi_Tenancy.Core.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContextExtension(this IServiceCollection services)
        {
            services.AddSingleton<ITenantProvider, TenantProvider>();
            services.AddDbContext<TenantDbContext>();
            services.AddDbContext<TenantAwareDbContext>();
            return services;
        }
    }
}
