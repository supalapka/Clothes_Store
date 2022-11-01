using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAccessLibrary.Migrations
{
    public partial class createSellerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Clothes",
                nullable: true,
                maxLength:450);

            migrationBuilder.AddForeignKey(
              name: "FK_Clothes_AspNetUsers_ApplicationUserId",
              table: "Clothes",
              column: "SellerId",
              principalTable: "AspNetUsers",
              principalColumn: "Id",
              onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Clothes");
        }
    }
}
