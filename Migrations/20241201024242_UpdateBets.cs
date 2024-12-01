using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApuestasDeportivasAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StrThumb",
                table: "Partidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsValidated",
                table: "Bets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StrThumb",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "IsValidated",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bets");
        }
    }
}
