using Microsoft.EntityFrameworkCore.Migrations;

namespace Clothes_Store.Data.Migrations
{
    public partial class userPromocodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsedPromocodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(maxLength:450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedPromocodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsedPromocodes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsedPromocodes_ApplicationUserId",
                table: "UsedPromocodes",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsedPromocodes");
        }
    }
}
