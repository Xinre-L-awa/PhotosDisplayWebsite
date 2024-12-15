using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotosDisplayWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewAccountGroup",
                table: "Accounts",
                newName: "AccountGroup");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountGroup",
                table: "Accounts",
                newName: "NewAccountGroup");
        }
    }
}
