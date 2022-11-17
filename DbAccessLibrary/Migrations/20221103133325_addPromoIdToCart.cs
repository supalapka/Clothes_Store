using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAccessLibrary.Migrations
{
    public partial class addPromoIdToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromocodeId",
                table: "Carts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_PromocodeId",
                table: "Carts",
                column: "PromocodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Promocodes_PromocodeId",
                table: "Carts",
                column: "PromocodeId",
                principalTable: "Promocodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Promocodes_PromocodeId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_PromocodeId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PromocodeId",
                table: "Carts");
        }
    }
}
