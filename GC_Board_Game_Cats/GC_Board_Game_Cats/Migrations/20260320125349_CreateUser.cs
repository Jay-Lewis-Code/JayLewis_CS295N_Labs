using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GC_Board_Game_Cats.Migrations
{
    /// <inheritdoc />
    public partial class CreateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_AppUsers_AppUserId",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppUsers",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_AppUsers_AppUserId",
                table: "BlogPosts",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_AppUsers_AppUserId",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppUsers",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_AppUsers_AppUserId",
                table: "BlogPosts",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
