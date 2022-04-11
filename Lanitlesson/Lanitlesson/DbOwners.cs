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
    public class DbOwners
    {
        public const string TableName = "Owners";
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<DbAutos> Autos { get; set; }

        public DbOwners()
        {
            Autos = new HashSet<DbAutos>();
        }
     
    }
    public class OwnersConfiguration : IEntityTypeConfiguration<DbOwners>
    {
        public void Configure(EntityTypeBuilder<DbOwners> builder)
        {
            builder.ToTable(DbOwners.TableName);
            builder.HasKey(t => t.ID);
            builder.HasMany(o => o.Autos).WithOne(w => w.Owners);
        }
    }
}
