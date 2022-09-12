using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class CatalogoUnidadDeLaMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cat_unidad_meta",
                columns: table => new
                {
                    id_unidad_meta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_nombre_unidad_meta = table.Column<string>(type: "varchar", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_unidad_meta", x => x.id_unidad_meta);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cat_unidad_meta");
        }
    }
}
