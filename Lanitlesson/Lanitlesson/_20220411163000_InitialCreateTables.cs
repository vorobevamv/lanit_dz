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
    [Migration("20220411163000_InitialCreateTables")]
    internal class InitialCreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable
                (
                name: DbAutos.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    OwnerID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbOwners.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbClients.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    License = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbClientsAutos.TableName,
                columns: table => new
                {
                    clientID = table.Column<Guid>(nullable: false),
                    autoID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsAutos", x => new {x.clientID, x.autoID}); //ключ по уникальному сочетанию двух столбцов
                }
                );
        }
    }
}
