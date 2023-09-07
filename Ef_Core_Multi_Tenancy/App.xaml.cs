using Ef_Core_Multi_Tenancy.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ef_Core_Multi_Tenancy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost hostBuilderContainer;

        public App()
        {
            this.hostBuilderContainer = this.CreateQuickBooksServiceHostBuilder();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            hostBuilderContainer.RunAsync();
        }

        private IHost CreateQuickBooksServiceHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureServices(service =>
            {
                service.AddLogging();
                service.AddDbContextExtension();
            }).Build();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            this.hostBuilderContainer.StopAsync();
        }
    }
}
