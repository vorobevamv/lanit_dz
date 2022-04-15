using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson02
{
    public class DbOwners
    {
        public const string TableName = "Owners";
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<DbClubs> Clubs { get; set; }

        public DbOwners()
        {
            Clubs = new HashSet<DbClubs>();
        }
    }
    public class OwnersConfiguration : IEntityTypeConfiguration<DbOwners>
    {
        public void Configure(EntityTypeBuilder<DbOwners> builder)
        {
            builder.ToTable(DbOwners.TableName);
            builder.HasKey(t => t.ID);
            builder.HasMany(c => c.Clubs).WithOne(o => o.Owners);
        }
    }
}
