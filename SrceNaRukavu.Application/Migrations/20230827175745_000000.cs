using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SrceNaRukavu.Application.Migrations
{
    /// <inheritdoc />
    public partial class _000000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
