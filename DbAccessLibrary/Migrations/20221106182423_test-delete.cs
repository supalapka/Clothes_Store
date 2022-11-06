using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAccessLibrary.Migrations
{
    public partial class testdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "CountSell",
                table: "Clothes",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Clothes",
                nullable: true,
                defaultValue: 0);
        }

         protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(    
                name: "CountSell",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Clothes");
        }
    }
}
