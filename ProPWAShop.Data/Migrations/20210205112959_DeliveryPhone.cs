using Microsoft.EntityFrameworkCore.Migrations;

namespace ProPWAShop.Data.Migrations
{
    public partial class DeliveryPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Deliverys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "Deliverys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetDescription",
                table: "Deliverys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Deliverys");

            migrationBuilder.DropColumn(
                name: "Target",
                table: "Deliverys");

            migrationBuilder.DropColumn(
                name: "TargetDescription",
                table: "Deliverys");
        }
    }
}
