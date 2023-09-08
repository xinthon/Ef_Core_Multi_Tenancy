using Ef_Core_Multi_Tenancy.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.Core
{
    public interface ITenantProvider
    {
        Tenant Tenant { get; set; }

        void SetTenant(Tenant tenant);

        Tenant GetTenants();

        event Action<Tenant> OnTenantChanged;
    }
}
