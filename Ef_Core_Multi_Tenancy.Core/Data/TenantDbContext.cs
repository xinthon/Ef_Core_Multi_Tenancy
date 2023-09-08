using Ef_Core_Multi_Tenancy.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.Core.Data
{
    public class TenantDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public TenantDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        // Define your tenant-specific entities as DbSet properties here
        public DbSet<Tenant> Tenants { get; set; }
    }
}
