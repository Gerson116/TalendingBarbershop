using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TalendingBarbershop.Data.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPaidTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPaidTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblRoles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblServices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    price = table.Column<decimal>(type: "decimal(5, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblServices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<int>(nullable: true),
                    is_paid = table.Column<bool>(nullable: true),
                    paid_type_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_paid_type_id_tblPaidTypes",
                        column: x => x.paid_type_id,
                        principalTable: "tblPaidTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    last_name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    phone = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    username = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    password = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    role_id = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(type: "date", nullable: true),
                    updated_at = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_role_id_tblRoles",
                        column: x => x.role_id,
                        principalTable: "tblRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_id = table.Column<int>(nullable: true),
                    order_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_id_tblOrderDetails",
                        column: x => x.order_id,
                        principalTable: "tblOrders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblQuotes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<int>(nullable: true),
                    user_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblQuotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_id_tblQuotes",
                        column: x => x.user_id,
                        principalTable: "tblUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetails_order_id",
                table: "tblOrderDetails",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrders_paid_type_id",
                table: "tblOrders",
                column: "paid_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblQuotes_user_id",
                table: "tblQuotes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_role_id",
                table: "tblUsers",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOrderDetails");

            migrationBuilder.DropTable(
                name: "tblQuotes");

            migrationBuilder.DropTable(
                name: "tblServices");

            migrationBuilder.DropTable(
                name: "tblOrders");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblPaidTypes");

            migrationBuilder.DropTable(
                name: "tblRoles");
        }
    }
}
