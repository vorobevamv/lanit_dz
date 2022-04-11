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
    public class DbClients
    {
        public const string TableName = "Clients";
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
       /* public ICollection<DbClientsAutos> ClientsAutos { get; set; }

        public DbClients()
        {
            ClientsAutos = new HashSet<DbClientsAutos>();
        }*/
    }
    public class ClientsConfiguration : IEntityTypeConfiguration<DbClients>
    {
        public void Configure(EntityTypeBuilder<DbClients> builder)
        {
            builder.ToTable(DbClients.TableName);
            builder.HasKey(t => t.ID);
          //  builder.HasMany(y => y.ClientsAutos).WithOne(c => c.Clients);
        }
    }
}
