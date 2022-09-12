using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class CatalogoAreaIncidencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cat_area_incidencia",
                columns: table => new
                {
                    id_area_incidencia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_descripcion_area = table.Column<string>(type: "varchar", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_area_incidencia", x => x.id_area_incidencia);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cat_area_incidencia");
        }
    }
}
