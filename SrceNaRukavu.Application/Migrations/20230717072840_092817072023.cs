using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SrceNaRukavu.Application.Migrations
{
    /// <inheritdoc />
    public partial class _092817072023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "SYSADM", "System admin" },
                    { 2, "OWN", "Owner" },
                    { 3, "MAN", "Manager" },
                    { 4, "CUS", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "AuthenticateId", "City", "Email", "Name", "RoleId", "Surname", "Telephone" },
                values: new object[] { 1, "Teslina ulica 7", 1, "Zagreb", "anak@gmail.com", "Ana", 2, "K.", "0913340123" });

            migrationBuilder.InsertData(
                table: "Authenticates",
                columns: new[] { "Id", "Password", "Token", "Username" },
                values: new object[] { 1, "1234", "", "bossman" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authenticates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
