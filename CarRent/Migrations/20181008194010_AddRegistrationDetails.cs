using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class AddRegistrationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationCountry",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistrationYear",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationCountry",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "RegistrationYear",
                table: "Vehicle");
        }
    }
}
