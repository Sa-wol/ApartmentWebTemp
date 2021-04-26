using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentWebTemp.Data.Migrations
{
    public partial class AddStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    StaffRole = table.Column<string>(nullable: true),
                    EmploymentStartDate = table.Column<DateTime>(nullable: false),
                    EmployemntEndDate = table.Column<DateTime>(nullable: false),
                    StaffWage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
