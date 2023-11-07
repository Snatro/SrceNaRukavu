using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SrceNaRukavu.Application.Migrations
{
    /// <inheritdoc />
    public partial class _210820231347 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authenticates");

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AuthenticateId",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "AuthenticateId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authenticates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authenticates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authenticates_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
    }
}
