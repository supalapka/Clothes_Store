using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAccessLibrary.Migrations
{
    public partial class promocodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromocodeId",
                table: "UsedPromocodes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Promocodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    DiscountPercentage = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsedPromocodes_PromocodeId",
                table: "UsedPromocodes",
                column: "PromocodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsedPromocodes_Promocodes_PromocodeId",
                table: "UsedPromocodes",
                column: "PromocodeId",
                principalTable: "Promocodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsedPromocodes_Promocodes_PromocodeId",
                table: "UsedPromocodes");

            migrationBuilder.DropTable(
                name: "Promocodes");

            migrationBuilder.DropIndex(
                name: "IX_UsedPromocodes_PromocodeId",
                table: "UsedPromocodes");

            migrationBuilder.DropColumn(
                name: "PromocodeId",
                table: "UsedPromocodes");
        }
    }
}
