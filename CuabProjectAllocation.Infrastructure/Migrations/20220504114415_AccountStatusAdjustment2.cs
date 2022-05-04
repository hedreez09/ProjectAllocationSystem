using Microsoft.EntityFrameworkCore.Migrations;

namespace CuabProjectAllocation.Infrastructure.Migrations
{
    public partial class AccountStatusAdjustment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountStatus",
                table: "ApplicationUsers",
                newName: "AccountConfirmationStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountConfirmationStatus",
                table: "ApplicationUsers",
                newName: "AccountStatus");
        }
    }
}
