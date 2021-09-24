using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NumberDecompose.Data.Migrations
{
    public partial class initDataDocker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Number",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "INT", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Version = table.Column<int>(type: "INT", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Number");
        }
    }
}
