using Microsoft.EntityFrameworkCore.Migrations;

namespace T1708EOauth2Server.Migrations
{
    public partial class UpdateDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scope",
                table: "Credential");

            migrationBuilder.AddColumn<string>(
                name: "Scopes",
                table: "Credential",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scopes",
                table: "Credential");

            migrationBuilder.AddColumn<int>(
                name: "Scope",
                table: "Credential",
                nullable: false,
                defaultValue: 0);
        }
    }
}
