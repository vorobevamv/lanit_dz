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
    public class DbCars
    {
        public const string TableName = "Cars";
        public Guid ID { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public int Year { get; set; }
        public Guid CompanyID { get; set; }
        public DbCompanies Companies { get; set; } //один хозяин
        public ICollection<DbCustomersCars> CustomersCars { get; set; } //много заказов

        public DbCars()
        {
            Companies = new DbCompanies();
            CustomersCars = new HashSet<DbCustomersCars>();
        }
    }
    public class CarsConfiguration : IEntityTypeConfiguration<DbCars>
    {
        public void Configure(EntityTypeBuilder<DbCars> builder)
        {
            builder.ToTable(DbCars.TableName);
            builder.HasKey(t => t.ID);
            builder.HasMany(z => z.CustomersCars).WithOne(a => a.Cars);
            builder.HasOne(w => w.Companies).WithMany(o => o.Cars);
        }
    }
}

