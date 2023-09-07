using Ef_Core_Multi_Tenancy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_Multi_Tenancy.Data
{
    public class TenantDbContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant { Id = Guid.NewGuid(), Name = "Tenant1", ConnectionString = "ConnectionString1" },
                new Tenant { Id = Guid.NewGuid(), Name = "Tenant2", ConnectionString = "ConnectionString2" }
            );
        }
    }
}