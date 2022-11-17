using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAccessLibrary.Migrations
{
    public partial class addCountSellToClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Promocodes_PromocodeId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CountSell",
                table: "Clothes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PromocodeId",
                table: "Carts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Promocodes_PromocodeId",
                table: "Carts",
                column: "PromocodeId",
                principalTable: "Promocodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Promocodes_PromocodeId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CountSell",
                table: "Clothes");

            migrationBuilder.AlterColumn<int>(
                name: "PromocodeId",
                table: "Carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Promocodes_PromocodeId",
                table: "Carts",
                column: "PromocodeId",
                principalTable: "Promocodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
