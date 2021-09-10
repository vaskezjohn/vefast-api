using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vefast_src.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AttributeValueTipoProducto_IDAttributeValue",
                table: "AttributeValueTipoProducto");

            migrationBuilder.RenameColumn(
                name: "attribute_value_id",
                table: "Products",
                newName: "tipoProductoID");

            migrationBuilder.RenameColumn(
                name: "products_id",
                table: "AttributeValue",
                newName: "AttributeValueTipoProductoID");

            migrationBuilder.AddColumn<Guid>(
                name: "UsersID",
                table: "Orders",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "AttributeValueID",
                table: "Attributes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Products_brand_id",
                table: "Products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_store_id",
                table: "Products",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_tipoProductoID",
                table: "Products",
                column: "tipoProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordersitem_product_id",
                table: "Ordersitem",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_orders_item_id",
                table: "Orders",
                column: "orders_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UsersID",
                table: "Orders",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_products_id",
                table: "Categories",
                column: "products_id");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_products_id",
                table: "Brands",
                column: "products_id");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueTipoProducto_IDAttributeValue",
                table: "AttributeValueTipoProducto",
                column: "IDAttributeValue",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValue_AttributeValueTipoProductoID",
                table: "AttributeValue",
                column: "AttributeValueTipoProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_AttributeValueID",
                table: "Attributes",
                column: "AttributeValueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_AttributeValue_AttributeValueID",
                table: "Attributes",
                column: "AttributeValueID",
                principalTable: "AttributeValue",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValue_AttributeValueTipoProducto_AttributeValueTipo~",
                table: "AttributeValue",
                column: "AttributeValueTipoProductoID",
                principalTable: "AttributeValueTipoProducto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Products_products_id",
                table: "Brands",
                column: "products_id",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_products_id",
                table: "Categories",
                column: "products_id",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Ordersitem_orders_item_id",
                table: "Orders",
                column: "orders_item_id",
                principalTable: "Ordersitem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UsersID",
                table: "Orders",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordersitem_Products_product_id",
                table: "Ordersitem",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brand_id",
                table: "Products",
                column: "brand_id",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_store_id",
                table: "Products",
                column: "store_id",
                principalTable: "Stores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TipoProducto_tipoProductoID",
                table: "Products",
                column: "tipoProductoID",
                principalTable: "TipoProducto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_AttributeValue_AttributeValueID",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValue_AttributeValueTipoProducto_AttributeValueTipo~",
                table: "AttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Products_products_id",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_products_id",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Ordersitem_orders_item_id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UsersID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordersitem_Products_product_id",
                table: "Ordersitem");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brand_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_store_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_TipoProducto_tipoProductoID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_brand_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_category_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_store_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_tipoProductoID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Ordersitem_product_id",
                table: "Ordersitem");

            migrationBuilder.DropIndex(
                name: "IX_Orders_orders_item_id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UsersID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Categories_products_id",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Brands_products_id",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValueTipoProducto_IDAttributeValue",
                table: "AttributeValueTipoProducto");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValue_AttributeValueTipoProductoID",
                table: "AttributeValue");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_AttributeValueID",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "UsersID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AttributeValueID",
                table: "Attributes");

            migrationBuilder.RenameColumn(
                name: "tipoProductoID",
                table: "Products",
                newName: "attribute_value_id");

            migrationBuilder.RenameColumn(
                name: "AttributeValueTipoProductoID",
                table: "AttributeValue",
                newName: "products_id");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueTipoProducto_IDAttributeValue",
                table: "AttributeValueTipoProducto",
                column: "IDAttributeValue");
        }
    }
}
