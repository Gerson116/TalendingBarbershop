using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TalendingBarbershop.Data.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "time",
                table: "tblQuotes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetails_service_id",
                table: "tblOrderDetails",
                column: "service_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrderDetails_tblServices_service_id",
                table: "tblOrderDetails",
                column: "service_id",
                principalTable: "tblServices",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderDetails_tblServices_service_id",
                table: "tblOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_tblOrderDetails_service_id",
                table: "tblOrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "time",
                table: "tblQuotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
