using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson
{
    internal class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress01;Database=OrdersDB; Trusted_Connection=True");
        }

        public DbSet<DbAutos> Autos { get; set; }
        public DbSet<DbOwners> Owners { get; set; }
        public DbSet<DbClients> Clients { get; set; }
        public DbSet<DbOrders> Orders { get; set; }
    }

    public class DbAutos
    {
        public Guid ID { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public int Year { get; set; }
        public Guid ownerID { get; set; }
    }
    public class DbOwners
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
    public class DbClients
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
    }
    [Keyless]
    public class DbOrders
    {
        public Guid clientID { get; set; }
        public Guid autoID { get; set; }
    }

    internal class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable
                (
                name: "Autos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    OwnerID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                { 
                table.PrimaryKey("PK_Autos", x=> x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: "Owners",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    License = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: "Orders",
                columns: table => new
                {
                    clientID = table.Column<Guid>(nullable: false),
                    autoID = table.Column<Guid>(nullable: false)
                }
                );
        }
    }

  /* public class DbOrdersConfiguration : IEntity
   {
        public void Configure(EntityTypeBuilder <DbOrders> builder)
        {
            builder.ToTable(DbOrders.Autos);
            builder.HasKey(t => t.ID);
            builder.HasOne(a => a.Autos).WithMany(a => a.Orders);
            builder.HasMany(o => o.Autos).WhithOne(o => o.Owners);

            builder.ToTable(DbOrders.Owners);
            builder.HasKey(t => t.ID);
            builder.HasOne(o => o.Owners).WithMany((o => o.Autos);

            builder.ToTable(DbOrders.Clients);
            builder.HasKey(t => t.ID);
            builder.HasOne(c => c.Clients).WithMany(c => c.Orders);

            builder.ToTable(DbOrders.Orders);
            builder.HasMany(r => r.Orders).WhithOne(r => r.Clints);
            builder.HasMany(e => e.Orders).WhithOne(e => e.Autos);
        }
   }*/
   
}








