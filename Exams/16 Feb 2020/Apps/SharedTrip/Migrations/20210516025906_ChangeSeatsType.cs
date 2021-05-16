using Microsoft.EntityFrameworkCore.Migrations;

namespace SharedTrip.Migrations
{
    public partial class ChangeSeatsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Seats",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Seats",
                table: "Trips",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
