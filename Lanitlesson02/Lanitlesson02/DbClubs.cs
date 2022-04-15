using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;



namespace Lanitlesson02
{
    public class DbClubs
    {
        public const string TableName = "Clubs";
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public Guid OwnerID { get; set; }
        public DbOwners Owners { get; set; }
        public ICollection<DbClubsVisitors> ClubsVisitors { get; set; }

        public DbClubs()
        {
            Owners = new DbOwners();
            ClubsVisitors = new HashSet<DbClubsVisitors>();
        }
    }
    public class ClubsConfiguration : IEntityTypeConfiguration<DbClubs>
    {
        public void Configure(EntityTypeBuilder<DbClubs> builder)
        {
            builder.ToTable(DbClubs.TableName);
            builder.HasKey(t => t.ID);
            builder.HasMany(cv => cv.ClubsVisitors).WithOne(c => c.Clubs);
            builder.HasOne(o => o.Owners).WithMany(c => c.Clubs);
        }
    }
}
