using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    /// <inheritdoc />
    public partial class updateWebAgenciaDbV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_AspNetUsers_UsuarioId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Local_LocalId",
                table: "Reserva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Local",
                table: "Local");

            migrationBuilder.RenameTable(
                name: "Reserva",
                newName: "Reservas");

            migrationBuilder.RenameTable(
                name: "Local",
                newName: "Locals");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_UsuarioId",
                table: "Reservas",
                newName: "IX_Reservas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_LocalId",
                table: "Reservas",
                newName: "IX_Reservas_LocalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "IdReserva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locals",
                table: "Locals",
                column: "IdLocal");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_AspNetUsers_UsuarioId",
                table: "Reservas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Locals_LocalId",
                table: "Reservas",
                column: "LocalId",
                principalTable: "Locals",
                principalColumn: "IdLocal",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_AspNetUsers_UsuarioId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Locals_LocalId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locals",
                table: "Locals");

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "Reserva");

            migrationBuilder.RenameTable(
                name: "Locals",
                newName: "Local");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reserva",
                newName: "IX_Reserva_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_LocalId",
                table: "Reserva",
                newName: "IX_Reserva_LocalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva",
                column: "IdReserva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Local",
                table: "Local",
                column: "IdLocal");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_AspNetUsers_UsuarioId",
                table: "Reserva",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Local_LocalId",
                table: "Reserva",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "IdLocal",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
