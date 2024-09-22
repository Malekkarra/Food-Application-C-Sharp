using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApplication.Migrations
{
    public partial class cart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "carts",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  RecipeId = table.Column<string>(type: "nvarchar(max)", nullable: true)  // Add this line for RecipeId
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_carts", x => x.Id);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carts");
        }
    }
}
