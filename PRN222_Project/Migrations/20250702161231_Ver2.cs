using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN222_Project.Migrations
{
    /// <inheritdoc />
    public partial class Ver2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_quantity",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "total_quantity",
                table: "Products",
                type: "int",
                nullable: true);
        }
    }
}
