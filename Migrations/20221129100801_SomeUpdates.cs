using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module4HW4.Migrations
{
    public partial class SomeUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "SomeDefaultValue",
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Payments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "SomeDefaultValue");
        }
    }
}
