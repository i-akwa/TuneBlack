using Microsoft.EntityFrameworkCore.Migrations;

namespace TuneBlack.Data.Migrations
{
    public partial class UpdateTracksToAddGenreAndProducer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Tracks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProducerName",
                table: "Tracks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "ProducerName",
                table: "Tracks");
        }
    }
}
