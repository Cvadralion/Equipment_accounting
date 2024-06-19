using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equipment_accounting.Migrations
{
    public partial class jopa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documentsequipments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documentsequipments");
        }
    }
}
