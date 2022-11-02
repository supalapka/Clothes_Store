using Microsoft.EntityFrameworkCore.Migrations;

namespace Clothes_Store.Data.Migrations
{
    public partial class renamePromocodeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
             name: "Promocode",
             newName: "Promocodes"
         );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
             name: "Promocodes",
             newName: "Promocode"
             );
        }
    }
}
