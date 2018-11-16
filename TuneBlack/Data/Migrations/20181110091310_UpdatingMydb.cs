using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TuneBlack.Data.Migrations
{
    public partial class UpdatingMydb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Tracks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistId",
                table: "Tracks",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
