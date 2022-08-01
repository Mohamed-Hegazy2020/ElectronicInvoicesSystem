using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicInvoicesSystem.Migrations
{
    public partial class GPCBrickCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GPCBrickCode",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPCBrickCode",
                table: "Item");
        }
    }
}
