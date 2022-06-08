using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service
{
    public class DbVisitors
    {
        public const string TableName = "Visitors";
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<DbClubsVisitors> ClubsVisitors { get; set; }

        public DbVisitors()
        {
            ClubsVisitors = new HashSet<DbClubsVisitors>();
        }
    }
    public class VisitorsConfiguration : IEntityTypeConfiguration<DbVisitors>
    {
        public void Configure(EntityTypeBuilder<DbVisitors> builder)
        {
            builder.ToTable(DbVisitors.TableName);
            builder.HasKey(t => t.ID);
            builder.HasMany(cv => cv.ClubsVisitors).WithOne(v => v.Visitors);
        }
    }
}
