using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApuestasDeportivasAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartidoId",
                table: "Bets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bets",
                newName: "MatchId");

            migrationBuilder.AddColumn<decimal>(
                name: "Odds",
                table: "Bets",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Potential",
                table: "Bets",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Bets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odds",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Potential",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bets");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Bets",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "PartidoId",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
