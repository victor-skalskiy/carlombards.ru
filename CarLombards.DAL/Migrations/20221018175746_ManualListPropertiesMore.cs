using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLombards.DAL.Migrations
{
    public partial class ManualListPropertiesMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManualListOrder",
                table: "PagesEntities",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManualListOrder",
                table: "PagesEntities");
        }
    }
}
