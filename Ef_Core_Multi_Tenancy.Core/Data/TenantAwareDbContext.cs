using Ef_Core_Multi_Tenancy.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.Core.Data
{
    public class TenantAwareDbContext : DbContext
    {
        private readonly ITenantProvider tenantProvider;

        public TenantAwareDbContext(ITenantProvider tenantProvider) { this.tenantProvider = tenantProvider; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(tenantProvider.Tenant.ConnectionString);
            }
        }
    }
}
