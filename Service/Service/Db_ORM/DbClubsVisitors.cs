using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service
{
    public class DbClubsVisitors
    {
        public const string TableName = "ClubsVisitors";
        public Guid ID { get; set; }
        public Guid ClubID { get; set; }
        public Guid VisitorID { get; set; }
        public DbClubs Clubs { get; set; }
        public DbVisitors Visitors { get; set; }

        public DbClubsVisitors()
        {
            Clubs = new DbClubs();
            Visitors = new DbVisitors();
        }
    }
    public class ClubsVisitorsConfiguration : IEntityTypeConfiguration<DbClubsVisitors>
    {
        public void Configure(EntityTypeBuilder<DbClubsVisitors> builder)
        {
            builder.ToTable(DbClubsVisitors.TableName);
            builder.HasKey(t => t.ID);
            builder.HasOne(v => v.Visitors).WithMany(cv => cv.ClubsVisitors);
            builder.HasOne(c => c.Clubs).WithMany(cv => cv.ClubsVisitors);
        }
    }
}
