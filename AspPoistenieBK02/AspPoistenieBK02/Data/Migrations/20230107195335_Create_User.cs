using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspPoistenieBK02.Data.Migrations
{
    public partial class Create_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserGender",
                table: "UserModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGender",
                table: "UserModel");
        }
    }
}
