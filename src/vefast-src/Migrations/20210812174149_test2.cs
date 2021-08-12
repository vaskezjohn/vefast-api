using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vefast_src.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sku = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<double>(type: "double", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "Text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    attribute_value_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    brand_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    category_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    store_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    availability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InsertUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_User_InsertUserID",
                        column: x => x.InsertUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_User_UpdateUserID",
                        column: x => x.UpdateUserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InsertUserID",
                table: "Products",
                column: "InsertUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdateUserID",
                table: "Products",
                column: "UpdateUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
