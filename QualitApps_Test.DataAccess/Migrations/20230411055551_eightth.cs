using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QualitApps_Test.DataAccess.Migrations
{
    public partial class eightth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "DriverId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "DriverId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
