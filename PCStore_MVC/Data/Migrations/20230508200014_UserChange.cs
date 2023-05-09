using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketProducts_Product_ProductId",
                schema: "Identity",
                table: "BasketProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Product_ProductId",
                schema: "Identity",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryId",
                schema: "Identity",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Producers_ProducerId",
                schema: "Identity",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "Identity",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "Identity",
                newName: "Products",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProducerId",
                schema: "Identity",
                table: "Products",
                newName: "IX_Products_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                schema: "Identity",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                schema: "Identity",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProducts_Products_ProductId",
                schema: "Identity",
                table: "BasketProducts",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                schema: "Identity",
                table: "OrderDetails",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Identity",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Identity",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_ProducerId",
                schema: "Identity",
                table: "Products",
                column: "ProducerId",
                principalSchema: "Identity",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketProducts_Products_ProductId",
                schema: "Identity",
                table: "BasketProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                schema: "Identity",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_ProducerId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                schema: "Identity",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Identity",
                newName: "Product",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProducerId",
                schema: "Identity",
                table: "Product",
                newName: "IX_Product_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                schema: "Identity",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "Identity",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketProducts_Product_ProductId",
                schema: "Identity",
                table: "BasketProducts",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Product_ProductId",
                schema: "Identity",
                table: "OrderDetails",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryId",
                schema: "Identity",
                table: "Product",
                column: "CategoryId",
                principalSchema: "Identity",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Producers_ProducerId",
                schema: "Identity",
                table: "Product",
                column: "ProducerId",
                principalSchema: "Identity",
                principalTable: "Producers",
                principalColumn: "ProducerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
