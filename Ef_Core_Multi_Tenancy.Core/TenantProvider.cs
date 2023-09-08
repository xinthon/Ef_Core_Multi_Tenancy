using Ef_Core_Multi_Tenancy.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.Core
{
    public class TenantProvider : ITenantProvider
    {
        public Tenant Tenant { get; set; }

        public event Action<Tenant> OnTenantChanged;

        public Tenant GetTenants() => this.Tenant;


        public void SetTenant(Tenant tenant)
        {
            this.OnTenantChanged?.Invoke(tenant);
            this.Tenant = tenant;
        }
    }
}
