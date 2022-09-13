using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class TablaAcciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cat_accion",
                columns: table => new
                {
                    id_n_accion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_desc_accion = table.Column<string>(type: "text", nullable: true),
                    fk_lin_estrate_accion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_accion", x => x.id_n_accion);
                    table.ForeignKey(
                        name: "fk_lin_estrategica_accion",
                        column: x => x.fk_lin_estrate_accion,
                        principalTable: "tb_cat_linea_estrategica",
                        principalColumn: "id_n_linea_estrategica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx01_accion",
                table: "tb_cat_accion",
                column: "fk_lin_estrate_accion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cat_accion");
        }
    }
}
