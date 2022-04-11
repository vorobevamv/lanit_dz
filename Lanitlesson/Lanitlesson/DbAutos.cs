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
    public class DbAutos
    {
        public const string TableName = "Autos";
        public Guid ID { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public int Year { get; set; }
        public Guid OwnerID { get; set; }
        public DbOwners Owners { get; set; } //один хозяин
       // public ICollection<DbClientsAutos> ClientsAutos { get; set; } //много заказов

        public DbAutos()
        {
            Owners = new DbOwners();
           // ClientsAutos = new HashSet<DbClientsAutos>();
        }
    }
    public class AutosConfiguration : IEntityTypeConfiguration<DbAutos>
    {
        public void Configure(EntityTypeBuilder<DbAutos> builder)
        {
            builder.ToTable(DbAutos.TableName);
            builder.HasKey(t => t.ID);
           // builder.HasMany(z => z.ClientsAutos).WithOne(a => a.Autos);
            builder.HasOne(w => w.Owners).WithMany(o => o.Autos);
        }
    }
}

