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
    public class DbCustomers
    {
        public const string TableName = "Customers";
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
        public ICollection<DbCustomersCars> CustomersCars { get; set; }

        public DbCustomers()
        {
            CustomersCars = new HashSet<DbCustomersCars>();
        }
    }
    public class CustomersConfiguration : IEntityTypeConfiguration<DbCustomers>
    {
        public void Configure(EntityTypeBuilder<DbCustomers> builder)
        {
            builder.ToTable(DbCustomers.TableName);
            builder.HasKey(t => t.ID);
            builder.HasMany(y => y.CustomersCars).WithOne(c => c.Customers);
        }
    }
}
