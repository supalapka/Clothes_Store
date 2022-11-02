using Microsoft.EntityFrameworkCore.Migrations;

namespace Clothes_Store.Data.Migrations
{
    public partial class renameUsedPromo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
             name: "UsedPromocode",
             newName: "UsedPromocodes"
         );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
             name: "UsedPromocodes",
             newName: "UsedPromocode"
             );
        }
    }
}
