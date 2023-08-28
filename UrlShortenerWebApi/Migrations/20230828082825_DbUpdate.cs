using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortenerWebApi.Migrations
{
    public partial class DbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urls_AspNetUsers_UserId",
                table: "Urls");

            migrationBuilder.DropIndex(
                name: "IX_Urls_UserId",
                table: "Urls");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Urls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Urls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_UserId",
                table: "Urls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_AspNetUsers_UserId",
                table: "Urls",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
