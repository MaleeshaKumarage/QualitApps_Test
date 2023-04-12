using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QualitApps_Test.DataAccess.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_DriverId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseUserUserId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BaseUserUserId",
                table: "Bookings",
                column: "BaseUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_BaseUserUserId",
                table: "Bookings",
                column: "BaseUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_BaseUserUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BaseUserUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BaseUserUserId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_DriverId",
                table: "Bookings",
                column: "DriverId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
