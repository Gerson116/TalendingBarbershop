using Microsoft.EntityFrameworkCore.Migrations;

namespace TalendingBarbershop.Data.Migrations
{
    public partial class rolesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblRoles",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Barbero" });

            migrationBuilder.InsertData(
                table: "tblRoles",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Cliente" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblRoles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblRoles",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
