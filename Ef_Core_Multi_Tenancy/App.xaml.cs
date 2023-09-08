using Ef_Core_Multi_Tenancy.Core.Extensions;
using Ef_Core_Multi_Tenancy.Extensions;
using Ef_Core_Multi_Tenancy.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows;

namespace Ef_Core_Multi_Tenancy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost hostBuilderContainer;
        private static bool _init = false;

        public App() { this.hostBuilderContainer = this.CreateQuickBooksServiceHostBuilder(); }


        private IHost CreateQuickBooksServiceHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(
                    config =>
                    {
                        config.AddJsonFile("app_settings.json", optional: true, reloadOnChange: true);
                    })
                .ConfigureServices(
                    services =>
                    {
                        services.AddLogging();
                        services.AddDbContextExtension();
                        services.AddViewModelExtension();
                        services.AddViewExtension();
                    })
                .Build();
        }


        private Window? m_window;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            this.hostBuilderContainer.RunAsync();


            if(!_init)
            {
                _init = true;

                m_window = this.hostBuilderContainer.Services.GetRequiredService<MainView>();
                m_window?.Activate();
                m_window?.Show();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            this.hostBuilderContainer.StopAsync();
        }
    }
}
