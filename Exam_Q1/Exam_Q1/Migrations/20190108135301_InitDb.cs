using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam_Q1.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ratio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Ratio" },
                values: new object[,]
                {
                    { "USD", 23260m },
                    { "EUR", 27061m },
                    { "AUD", 16798m },
                    { "JPY", 20704m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
