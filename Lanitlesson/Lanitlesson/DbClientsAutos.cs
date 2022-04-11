using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson
{
    public class DbClientsAutos
    {
        public const string TableName = "ClientsAutos";
        public Guid clientID { get; set; }
        public Guid autoID { get; set; }
        /*public DbAutos Autos { get; set; }
        public DbClients Clients { get; set; }

        public DbClientsAutos()
        {
            Autos = new DbAutos();
            Clients = new DbClients();
        }*/

    }
    public class ClientsAutosConfiguration : IEntityTypeConfiguration<DbClientsAutos>
    {
        public void Configure(EntityTypeBuilder<DbClientsAutos> builder)
        {
            builder.ToTable(DbClientsAutos.TableName);
           // builder.HasOne(c => c.Clients).WithMany(y => y.ClientsAutos);
           // builder.HasOne(a => a.Autos).WithMany(z => z.ClientsAutos);
            builder.HasKey(n => new {n.clientID, n.autoID});
        }
    }
}
