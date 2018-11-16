using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TuneBlack.Data.Migrations
{
    public partial class UpdateTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Tracks",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "Tracks",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",                
                onDelete: ReferentialAction.NoAction,
                onUpdate:ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate:ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Tracks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "Tracks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
