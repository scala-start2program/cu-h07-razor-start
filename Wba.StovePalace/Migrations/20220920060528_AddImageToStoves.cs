using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wba.StovePalace.Migrations
{
    public partial class AddImageToStoves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Stove",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Stove");
        }
    }
}
