using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dvp_server.Migrations
{
    /// <inheritdoc />
    public partial class users_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usarios_Personas_PersonaId",
                table: "Usarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usarios",
                table: "Usarios");

            migrationBuilder.RenameTable(
                name: "Usarios",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usarios_PersonaId",
                table: "Usuarios",
                newName: "IX_Usuarios_PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Personas_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Personas_PersonaId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usarios",
                newName: "IX_Usarios_PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usarios",
                table: "Usarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usarios_Personas_PersonaId",
                table: "Usarios",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
