using Microsoft.EntityFrameworkCore.Migrations;

namespace CuabProjectAllocation.Infrastructure.Migrations
{
    public partial class UpdateApplicationUserDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "LoginFailedCount",
                table: "ApplicationUsers",
                newName: "FailedLoginCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FailedLoginCount",
                table: "ApplicationUsers",
                newName: "LoginFailedCount");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
