using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HGRM.Migrations
{
    public partial class complete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePage",
                columns: table => new
                {
                    homePageid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Febuary = table.Column<string>(nullable: true),
                    January = table.Column<string>(nullable: true),
                    april = table.Column<string>(nullable: true),
                    august = table.Column<string>(nullable: true),
                    december = table.Column<string>(nullable: true),
                    july = table.Column<string>(nullable: true),
                    june = table.Column<string>(nullable: true),
                    march = table.Column<string>(nullable: true),
                    may = table.Column<string>(nullable: true),
                    november = table.Column<string>(nullable: true),
                    october = table.Column<string>(nullable: true),
                    september = table.Column<string>(nullable: true),
                    welcomeBody = table.Column<string>(nullable: true),
                    welcomeTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePage", x => x.homePageid);
                });
        }
    }
}
