using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Repository.Migrations
{
    public partial class InitialUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderedMovieId",
                table: "MovieInOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieInOrder_OrderedMovieId",
                table: "MovieInOrder",
                column: "OrderedMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieInOrder_Movies_OrderedMovieId",
                table: "MovieInOrder",
                column: "OrderedMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieInOrder_Movies_OrderedMovieId",
                table: "MovieInOrder");

            migrationBuilder.DropIndex(
                name: "IX_MovieInOrder_OrderedMovieId",
                table: "MovieInOrder");

            migrationBuilder.DropColumn(
                name: "OrderedMovieId",
                table: "MovieInOrder");
        }
    }
}
