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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //для работы классов конфигураций
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress01;Database=DBRentCars; Trusted_Connection=True");
        }

        public DbSet<DbAutos> Autos { get; set; }
        public DbSet<DbOwners> Owners { get; set; }
        public DbSet<DbClients> Clients { get; set; }
        public DbSet<DbClientsAutos> ClientsAutos { get; set; }
    }
   
}








