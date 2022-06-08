using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson
{
    internal class DatabaseContext : DbContext
    {
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //для работы классов конфигураций
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=DBRentCars; Trusted_Connection=True");
        }

        public DbSet<DbCars> Cars { get; set; }
        public DbSet<DbCompanies> Companies { get; set; }
        public DbSet<DbCustomers> Customers { get; set; }
        public DbSet<DbCustomersCars> CustomersCars { get; set; }
    }
   
}








