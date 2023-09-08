using Ef_Core_Multi_Tenancy.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.Extensions
{
    public static class ViewExtensions
    {
        public static IServiceCollection AddViewExtension(this IServiceCollection services)
        {
            services.AddSingleton<MainView>();
            return services;
        }
    }
}
