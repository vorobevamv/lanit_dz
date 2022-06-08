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
    public class DbCustomersCars
    {
        public const string TableName = "CustomersCars";
        public Guid ID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid CarID { get; set; }
        public DbCars Cars { get; set; }
        public DbCustomers Customers { get; set; }

        public DbCustomersCars()
        {
            Cars = new DbCars();
            Customers = new DbCustomers();
        }

    }
    public class CustomersCarsConfiguration : IEntityTypeConfiguration<DbCustomersCars>
    {
        public void Configure(EntityTypeBuilder<DbCustomersCars> builder)
        {
            builder.ToTable(DbCustomersCars.TableName);
            builder.HasKey(t => t.ID);
            builder.HasOne(c => c.Customers).WithMany(y => y.CustomersCars);
            builder.HasOne(a => a.Cars).WithMany(z => z.CustomersCars);
            //builder.HasKey(n => new {n.clientID, n.autoID});// - для ключа по двум столбцам
        }
    }
}
