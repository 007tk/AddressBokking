using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBooking.Infrastructure.Migrations
{
    public partial class Renamecoloumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Contacts",
                newName: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Contacts",
                newName: "isDeleted");
        }
    }
}
