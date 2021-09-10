using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vefast_src.Migrations
{
    public partial class stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    IDProducts = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InsertDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InsertUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stock_Products_IDProducts",
                        column: x => x.IDProducts,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Users_InsertUserID",
                        column: x => x.InsertUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Users_UpdateUserID",
                        column: x => x.UpdateUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoProducto",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    tipoProduct = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProductsID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InsertDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InsertUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProducto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TipoProducto_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoProducto_Users_InsertUserID",
                        column: x => x.InsertUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoProducto_Users_UpdateUserID",
                        column: x => x.UpdateUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AttributeValueTipoProducto",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IDAttributeValue = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IDTipoProducto = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InsertDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InsertUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateUserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValueTipoProducto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttributeValueTipoProducto_AttributeValue_IDAttributeValue",
                        column: x => x.IDAttributeValue,
                        principalTable: "AttributeValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValueTipoProducto_TipoProducto_IDTipoProducto",
                        column: x => x.IDTipoProducto,
                        principalTable: "TipoProducto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValueTipoProducto_Users_InsertUserID",
                        column: x => x.InsertUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValueTipoProducto_Users_UpdateUserID",
                        column: x => x.UpdateUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueTipoProducto_IDAttributeValue",
                table: "AttributeValueTipoProducto",
                column: "IDAttributeValue");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueTipoProducto_IDTipoProducto",
                table: "AttributeValueTipoProducto",
                column: "IDTipoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueTipoProducto_InsertUserID",
                table: "AttributeValueTipoProducto",
                column: "InsertUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueTipoProducto_UpdateUserID",
                table: "AttributeValueTipoProducto",
                column: "UpdateUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_IDProducts",
                table: "Stock",
                column: "IDProducts");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_InsertUserID",
                table: "Stock",
                column: "InsertUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UpdateUserID",
                table: "Stock",
                column: "UpdateUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoProducto_InsertUserID",
                table: "TipoProducto",
                column: "InsertUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoProducto_ProductsID",
                table: "TipoProducto",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoProducto_UpdateUserID",
                table: "TipoProducto",
                column: "UpdateUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeValueTipoProducto");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "TipoProducto");
        }
    }
}
