using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotosDisplayWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UserToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewAccounts");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewAccountGroup = table.Column<int>(type: "int", nullable: false),
                    RealName = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Uid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.CreateTable(
                name: "NewAccounts",
                columns: table => new
                {
                    Uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewAccountGroup = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RealName = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewAccounts", x => x.Uid);
                });
        }
    }
}
