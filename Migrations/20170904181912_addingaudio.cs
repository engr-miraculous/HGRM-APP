using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HGRM.Migrations
{
    public partial class addingaudio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hgrmAudioMessage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HgrmDataID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hgrmAudioMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_hgrmAudioMessage_HgrmData_HgrmDataID",
                        column: x => x.HgrmDataID,
                        principalTable: "HgrmData",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hgrmWrittenMessage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HgrmDataID = table.Column<int>(nullable: false),
                    Sermon = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hgrmWrittenMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_hgrmWrittenMessage_HgrmData_HgrmDataID",
                        column: x => x.HgrmDataID,
                        principalTable: "HgrmData",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hgrmAudioMessage_HgrmDataID",
                table: "hgrmAudioMessage",
                column: "HgrmDataID");

            migrationBuilder.CreateIndex(
                name: "IX_hgrmWrittenMessage_HgrmDataID",
                table: "hgrmWrittenMessage",
                column: "HgrmDataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hgrmAudioMessage");

            migrationBuilder.DropTable(
                name: "hgrmWrittenMessage");
        }
    }
}
