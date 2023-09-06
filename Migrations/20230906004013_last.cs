using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karem_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustmerID",
                table: "orders",
                newName: "ProductName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "orders",
                newName: "CustmerID");
        }
    }
}
