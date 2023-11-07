using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SrceNaRukavu.Application.Migrations
{
    /// <inheritdoc />
    public partial class _210820231808 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Roles_RoleId",
                table: "Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Roles_RoleId",
                table: "Person",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Roles_RoleId",
                table: "Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Roles_RoleId",
                table: "Person",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
