﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBooking.Infrastructure.Migrations
{
    public partial class AddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Contacts");
        }
    }
}
