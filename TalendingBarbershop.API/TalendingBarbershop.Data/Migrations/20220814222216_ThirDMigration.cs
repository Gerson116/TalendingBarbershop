using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TalendingBarbershop.Data.Migrations
{
    public partial class ThirDMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_id_tblQuotes",
                table: "tblQuotes");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "tblQuotes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "time",
                table: "tblQuotes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_id_tblQuotes",
                table: "tblQuotes",
                column: "user_id",
                principalTable: "tblUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_id_tblQuotes",
                table: "tblQuotes");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "tblQuotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "time",
                table: "tblQuotes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_user_id_tblQuotes",
                table: "tblQuotes",
                column: "user_id",
                principalTable: "tblUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
