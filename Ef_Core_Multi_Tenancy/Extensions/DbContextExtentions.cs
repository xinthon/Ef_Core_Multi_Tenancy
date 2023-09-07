using Ef_Core_Multi_Tenancy.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContextExtension(this IServiceCollection services)
        {
            services.AddDbContext<TenantDbContext>();
            services.AddDbContext<TenantAwareDbContext>();

            return services;
        }
    }
}
