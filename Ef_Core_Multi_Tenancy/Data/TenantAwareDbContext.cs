using Ef_Core_Multi_Tenancy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.Data
{
    public class TenantAwareDbContext : DbContext
    {
        private readonly Tenant _tenant;

        public TenantAwareDbContext(DbContextOptions<TenantAwareDbContext> options, Tenant tenant) : base(options)
        {
            _tenant = tenant ?? throw new ArgumentNullException(nameof(tenant));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_tenant.ConnectionString);
            }
        }
    }
}
