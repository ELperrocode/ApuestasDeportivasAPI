using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApuestasDeportivasAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurePartidoPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Partidos",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Partidos");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Partidos",
                newName: "StrTime");

            migrationBuilder.RenameColumn(
                name: "HomeTeam",
                table: "Partidos",
                newName: "StrStatus");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Partidos",
                newName: "StrLeague");

            migrationBuilder.RenameColumn(
                name: "AwayTeam",
                table: "Partidos",
                newName: "StrHomeTeamBadge");

            migrationBuilder.AddColumn<string>(
                name: "IdEvent",
                table: "Partidos",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DateEvent",
                table: "Partidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IntAwayScore",
                table: "Partidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IntHomeScore",
                table: "Partidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StrAwayTeam",
                table: "Partidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StrAwayTeamBadge",
                table: "Partidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StrEvent",
                table: "Partidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StrHomeTeam",
                table: "Partidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partidos",
                table: "Partidos",
                column: "IdEvent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Partidos",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "IdEvent",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "DateEvent",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "IntAwayScore",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "IntHomeScore",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "StrAwayTeam",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "StrAwayTeamBadge",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "StrEvent",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "StrHomeTeam",
                table: "Partidos");

            migrationBuilder.RenameColumn(
                name: "StrTime",
                table: "Partidos",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "StrStatus",
                table: "Partidos",
                newName: "HomeTeam");

            migrationBuilder.RenameColumn(
                name: "StrLeague",
                table: "Partidos",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "StrHomeTeamBadge",
                table: "Partidos",
                newName: "AwayTeam");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Partidos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partidos",
                table: "Partidos",
                column: "Id");
        }
    }
}
