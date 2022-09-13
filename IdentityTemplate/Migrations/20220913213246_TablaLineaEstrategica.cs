using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class TablaLineaEstrategica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ln_descripcion_impacto",
                table: "tb_cat_eje_tematico",
                newName: "ln_descripcion_eje");

            migrationBuilder.CreateTable(
                name: "tb_cat_linea_estrategica",
                columns: table => new
                {
                    id_n_linea_estrategica = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_desc_estrategia = table.Column<string>(type: "text", nullable: true),
                    fk_eje_tematico_lin_estrate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_linea_estrategica", x => x.id_n_linea_estrategica);
                    table.ForeignKey(
                        name: "fk_eje_tematico_lin_estrate",
                        column: x => x.fk_eje_tematico_lin_estrate,
                        principalTable: "tb_cat_eje_tematico",
                        principalColumn: "id_n_eje_tematico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx01_linea_estrateg",
                table: "tb_cat_linea_estrategica",
                column: "fk_eje_tematico_lin_estrate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cat_linea_estrategica");

            migrationBuilder.RenameColumn(
                name: "ln_descripcion_eje",
                table: "tb_cat_eje_tematico",
                newName: "ln_descripcion_impacto");
        }
    }
}
