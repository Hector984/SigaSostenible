using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class Catalogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NivelSeguimiento",
                columns: table => new
                {
                    NivelSeguimientoId = table.Column<string>(type: "varchar", nullable: false),
                    Nivel = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelSeguimiento", x => x.NivelSeguimientoId);
                });

            migrationBuilder.CreateTable(
                name: "PoliticaAccion",
                columns: table => new
                {
                    PoliticaAccionId = table.Column<string>(type: "varchar", nullable: false),
                    NombrePoliticaAccion = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticaAccion", x => x.PoliticaAccionId);
                });

            migrationBuilder.CreateTable(
                name: "TipoInstitucion",
                columns: table => new
                {
                    TipoInstitucionId = table.Column<string>(type: "varchar", nullable: false),
                    Institucion = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInstitucion", x => x.TipoInstitucionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NivelSeguimiento");

            migrationBuilder.DropTable(
                name: "PoliticaAccion");

            migrationBuilder.DropTable(
                name: "TipoInstitucion");
        }
    }
}
