using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentWebTemp.Data.Migrations
{
    public partial class AddUnitLease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitLeases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UnitNumber = table.Column<int>(nullable: false),
                    UnitFloor = table.Column<int>(nullable: false),
                    MonthlyRent = table.Column<int>(nullable: false),
                    UnitDescription = table.Column<string>(nullable: true),
                    LeaseStarting = table.Column<DateTime>(nullable: false),
                    LeaseEnding = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitLeases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitLeases");
        }
    }
}
