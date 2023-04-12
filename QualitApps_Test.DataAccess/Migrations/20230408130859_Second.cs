using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QualitApps_Test.DataAccess.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_DriverId",
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
                name: "FK_Bookings_Customers_BaseUserUserId",
                table: "Bookings",
                column: "BaseUserUserId",
                principalTable: "Customers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_DriverId",
                table: "Bookings",
                column: "DriverId",
                principalTable: "Customers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_BaseUserUserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_DriverId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BaseUserUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BaseUserUserId",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_DriverId",
                table: "Bookings",
                column: "DriverId",
                principalTable: "Customers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
