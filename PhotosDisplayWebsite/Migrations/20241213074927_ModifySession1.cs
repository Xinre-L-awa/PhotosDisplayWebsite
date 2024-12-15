using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotosDisplayWebsite.Migrations
{
    /// <inheritdoc />
    public partial class ModifySession1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Accounts_AccountUid",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_AccountUid",
                table: "Sessions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AccountUid",
                table: "Sessions",
                column: "AccountUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Accounts_AccountUid",
                table: "Sessions",
                column: "AccountUid",
                principalTable: "Accounts",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
