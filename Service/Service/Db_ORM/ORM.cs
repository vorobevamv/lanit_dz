using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service
{
    public class DatabaseContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=DBInterests; Trusted_Connection=True");
        }

        public DbSet<DbClubs> Clubs { get; set; }
        public DbSet<DbOwners> Owners { get; set; }
        public DbSet<DbVisitors> Visitors { get; set; }
        public DbSet<DbClubsVisitors> ClubsVisitors { get; set; }
    }
}
