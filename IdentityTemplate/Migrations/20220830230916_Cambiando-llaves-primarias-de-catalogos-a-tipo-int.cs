using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class Cambiandollavesprimariasdecatalogosatipoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoInstitucion",
                table: "TipoInstitucion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliticaAccion",
                table: "PoliticaAccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NivelSeguimiento",
                table: "NivelSeguimiento");

            migrationBuilder.RenameTable(
                name: "TipoInstitucion",
                newName: "TipoInstituciones");

            migrationBuilder.RenameTable(
                name: "PoliticaAccion",
                newName: "PoliticaAcciones");

            migrationBuilder.RenameTable(
                name: "NivelSeguimiento",
                newName: "NivelesSeguimiento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoInstituciones",
                table: "TipoInstituciones",
                column: "TipoInstitucionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliticaAcciones",
                table: "PoliticaAcciones",
                column: "PoliticaAccionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NivelesSeguimiento",
                table: "NivelesSeguimiento",
                column: "NivelSeguimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoInstituciones",
                table: "TipoInstituciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliticaAcciones",
                table: "PoliticaAcciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NivelesSeguimiento",
                table: "NivelesSeguimiento");

            migrationBuilder.RenameTable(
                name: "TipoInstituciones",
                newName: "TipoInstitucion");

            migrationBuilder.RenameTable(
                name: "PoliticaAcciones",
                newName: "PoliticaAccion");

            migrationBuilder.RenameTable(
                name: "NivelesSeguimiento",
                newName: "NivelSeguimiento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoInstitucion",
                table: "TipoInstitucion",
                column: "TipoInstitucionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliticaAccion",
                table: "PoliticaAccion",
                column: "PoliticaAccionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NivelSeguimiento",
                table: "NivelSeguimiento",
                column: "NivelSeguimientoId");
        }
    }
}
