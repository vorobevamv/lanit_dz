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
    public class DbCompanies
    {
        public const string TableName = "Companies";
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<DbCars> Cars { get; set; }

        public DbCompanies()
        {
            Cars = new HashSet<DbCars>();
        }
     
    }
    public class CompaniesConfiguration : IEntityTypeConfiguration<DbCompanies>
    {
        public void Configure(EntityTypeBuilder<DbCompanies> builder)
        {
            builder.ToTable(DbCompanies.TableName);
            builder.HasKey(t => t.ID);
            builder.HasMany(o => o.Cars).WithOne(w => w.Companies);
        }
    }
}
