using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProducerChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Identity",
                table: "Producers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Identity",
                table: "Producers",
                type: "varchar(128)",
                unicode: false,
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
