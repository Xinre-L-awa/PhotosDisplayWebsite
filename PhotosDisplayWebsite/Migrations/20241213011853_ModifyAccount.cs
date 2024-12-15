using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotosDisplayWebsite.Migrations
{
    /// <inheritdoc />
    public partial class ModifyAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealName",
                table: "Accounts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "RealName",
                table: "Accounts",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }
    }
}
