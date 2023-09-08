using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors.Helpers;
using Ef_Core_Multi_Tenancy.Core;
using Ef_Core_Multi_Tenancy.Core.Data;
using Ef_Core_Multi_Tenancy.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IConfiguration configuration;
        private readonly ITenantProvider tenantProvider;
        private readonly TenantDbContext tenantDbContext;
        private readonly TenantAwareDbContext tenantAwareDbContext;

        public MainViewModel(
            IConfiguration configuration,
            TenantDbContext tenantDbContext,
            TenantAwareDbContext tenantAwareDbContext,
            ITenantProvider tenantProvider)
        {
            this.configuration = configuration;
            this.tenantDbContext = tenantDbContext;
            this.tenantAwareDbContext = tenantAwareDbContext;
            this.tenantProvider = tenantProvider;
        }

        public Tenant Tenant { get => this.GetValue<Tenant>(); set => this.SetValue(value); }


        public void SetTenant()
        {
            tenantProvider.SetTenant(this.tenantDbContext.Tenants.ToList().LastOrDefault());
            this.Tenant = tenantProvider.GetTenants();
        }

        public void RunMigration()
        {
            tenantAwareDbContext.Database.Migrate();
        }

        public void UpdateDateBase()
        {
            tenantAwareDbContext.Database.EnsureCreated();
        }
    }
}
