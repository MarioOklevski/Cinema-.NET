using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Web.Data.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoviePrice",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MovieInShoppingCarts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoviePrice",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MovieInShoppingCarts");
        }
    }
}
