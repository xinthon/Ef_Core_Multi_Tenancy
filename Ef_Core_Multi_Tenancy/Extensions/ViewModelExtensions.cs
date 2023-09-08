using Ef_Core_Multi_Tenancy.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.Mvvm.POCO;

namespace Ef_Core_Multi_Tenancy.Extensions
{
    public static class ViewModelExtensions
    {
        public static IServiceCollection AddViewModelExtension(this IServiceCollection services)
        {
            services.AddSingleton(typeof(MainViewModel), ViewModelSource.GetPOCOType(typeof(MainViewModel)));
            return services;
        }
    }
}
