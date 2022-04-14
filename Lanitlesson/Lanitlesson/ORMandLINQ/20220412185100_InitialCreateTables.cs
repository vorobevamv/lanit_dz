using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson
{
    [DbContextAttribute(typeof(DatabaseContext))]
    [Migration("20220412185100_InitialCreateTables")]
    internal class InitialCreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable
                (
                name: DbCars.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    CompanyID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbCompanies.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbCustomers.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    License = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbCustomersCars.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: false),
                    CarID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    //table.PrimaryKey("PK_ClientsAutos", x => new { x.clientID, x.autoID }); //ключ по уникальному сочетанию двух столбцов
                    table.PrimaryKey("PK_CustomersCars", x => x.ID);
                }
                );
        }
    }
}
