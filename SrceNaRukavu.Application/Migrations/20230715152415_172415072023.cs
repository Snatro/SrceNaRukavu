using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SrceNaRukavu.Application.Migrations
{
    /// <inheritdoc />
    public partial class _172415072023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorizes");

            migrationBuilder.RenameColumn(
                name: "CredentialsId",
                table: "Person",
                newName: "AuthenticateId");

            migrationBuilder.CreateTable(
                name: "Authenticates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authenticates");

            migrationBuilder.RenameColumn(
                name: "AuthenticateId",
                table: "Person",
                newName: "CredentialsId");

            migrationBuilder.CreateTable(
                name: "Authorizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorizes_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
