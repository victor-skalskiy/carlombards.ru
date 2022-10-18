using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLombards.DAL.Migrations
{
    public partial class ManualListProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsManualList",
                table: "PagesEntities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ManualListTitle",
                table: "PagesEntities",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManualList",
                table: "PagesEntities");

            migrationBuilder.DropColumn(
                name: "ManualListTitle",
                table: "PagesEntities");
        }
    }
}
