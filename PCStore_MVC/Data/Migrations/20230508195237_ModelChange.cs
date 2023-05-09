using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "dbo",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "dbo",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "dbo",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "dbo",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "dbo",
                newName: "User",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "dbo",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "dbo",
                newName: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "dbo",
                newName: "Product",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Producers",
                schema: "dbo",
                newName: "Producers",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "dbo",
                newName: "Orders",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                schema: "dbo",
                newName: "OrderDetails",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "dbo",
                newName: "Categories",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "BasketProducts",
                schema: "dbo",
                newName: "BasketProducts",
                newSchema: "Identity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "UserTokens",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "UserRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "UserLogins",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "UserClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Identity",
                newName: "User",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "RoleClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "Role",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "Identity",
                newName: "Product",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Producers",
                schema: "Identity",
                newName: "Producers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "Identity",
                newName: "Orders",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                schema: "Identity",
                newName: "OrderDetails",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "Identity",
                newName: "Categories",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BasketProducts",
                schema: "Identity",
                newName: "BasketProducts",
                newSchema: "dbo");
        }
    }
}
