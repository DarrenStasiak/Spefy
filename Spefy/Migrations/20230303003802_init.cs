using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spefy.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Generes = table.Column<string>(type: "TEXT", nullable: false),
                    Acousticness = table.Column<float>(type: "REAL", nullable: false),
                    Danceability = table.Column<float>(type: "REAL", nullable: false),
                    Energy = table.Column<float>(type: "REAL", nullable: false),
                    Instrumentalness = table.Column<float>(type: "REAL", nullable: false),
                    Key = table.Column<int>(type: "INTEGER", nullable: false),
                    Liveness = table.Column<float>(type: "REAL", nullable: false),
                    Loudness = table.Column<float>(type: "REAL", nullable: false),
                    Mode = table.Column<int>(type: "INTEGER", nullable: false),
                    Speechiness = table.Column<float>(type: "REAL", nullable: false),
                    Tempo = table.Column<float>(type: "REAL", nullable: false),
                    Valence = table.Column<float>(type: "REAL", nullable: false),
                    Time_signature = table.Column<int>(type: "INTEGER", nullable: false),
                    Popularity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
