using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DL.Migrations
{
    public partial class trytry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Players = table.Column<int>(type: "integer", nullable: false),
                    GameTurn = table.Column<int>(type: "integer", nullable: false),
                    p1Name = table.Column<string>(type: "text", nullable: true),
                    p2Name = table.Column<string>(type: "text", nullable: true),
                    p3Name = table.Column<string>(type: "text", nullable: true),
                    p4Name = table.Column<string>(type: "text", nullable: true),
                    P1x = table.Column<double>(type: "double precision", nullable: false),
                    P1y = table.Column<double>(type: "double precision", nullable: false),
                    P2x = table.Column<double>(type: "double precision", nullable: false),
                    P2y = table.Column<double>(type: "double precision", nullable: false),
                    P3x = table.Column<double>(type: "double precision", nullable: false),
                    P3y = table.Column<double>(type: "double precision", nullable: false),
                    P4x = table.Column<double>(type: "double precision", nullable: false),
                    P4y = table.Column<double>(type: "double precision", nullable: false),
                    Action = table.Column<int>(type: "integer", nullable: false),
                    ActionID = table.Column<int>(type: "integer", nullable: false),
                    TargetName = table.Column<string>(type: "text", nullable: true),
                    P1MaxHP = table.Column<int>(type: "integer", nullable: false),
                    P2MaxHP = table.Column<int>(type: "integer", nullable: false),
                    P3MaxHP = table.Column<int>(type: "integer", nullable: false),
                    P4MaxHP = table.Column<int>(type: "integer", nullable: false),
                    P1HP = table.Column<int>(type: "integer", nullable: false),
                    P2HP = table.Column<int>(type: "integer", nullable: false),
                    P3HP = table.Column<int>(type: "integer", nullable: false),
                    P4HP = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFirst = table.Column<string>(type: "text", nullable: true),
                    UserSecond = table.Column<string>(type: "text", nullable: true),
                    UserThird = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    GamesPlayed = table.Column<int>(type: "integer", nullable: false),
                    GamesWon = table.Column<int>(type: "integer", nullable: false),
                    TotalKills = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
