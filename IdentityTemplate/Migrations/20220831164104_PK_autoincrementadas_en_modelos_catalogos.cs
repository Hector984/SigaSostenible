using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class PK_autoincrementadas_en_modelos_catalogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoInstitucionId",
                table: "TipoInstituciones",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "PoliticaAccionId",
                table: "PoliticaAcciones",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "NivelSeguimientoId",
                table: "NivelesSeguimiento",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "Institucionindex",
                table: "TipoInstituciones",
                column: "Institucion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NombrePoliticaAccionIndex",
                table: "PoliticaAcciones",
                column: "NombrePoliticaAccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NivelIndex",
                table: "NivelesSeguimiento",
                column: "Nivel",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Institucionindex",
                table: "TipoInstituciones");

            migrationBuilder.DropIndex(
                name: "NombrePoliticaAccionIndex",
                table: "PoliticaAcciones");

            migrationBuilder.DropIndex(
                name: "NivelIndex",
                table: "NivelesSeguimiento");

            migrationBuilder.AlterColumn<string>(
                name: "TipoInstitucionId",
                table: "TipoInstituciones",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "PoliticaAccionId",
                table: "PoliticaAcciones",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "NivelSeguimientoId",
                table: "NivelesSeguimiento",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
