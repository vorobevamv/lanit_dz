using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lanitlesson02
{
    [DbContextAttribute(typeof(DatabaseContext))]
    [Migration("20220415143000_InitialCreateTables")]
    internal class InitialCreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable
                (
                name: DbClubs.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    OwnerID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbOwners.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbVisitors.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.ID);
                }
                );

            migrationBuilder.CreateTable
                (
                name: DbClubsVisitors.TableName,
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClubID = table.Column<Guid>(nullable: false),
                    VisitorID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsVisitors", x => x.ID);
                }
                );
        }
    }
}