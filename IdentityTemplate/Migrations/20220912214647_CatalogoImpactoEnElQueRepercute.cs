using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class CatalogoImpactoEnElQueRepercute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ln_politica",
                table: "tb_cat_politica",
                type: "varchar",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tb_cat_impacto",
                columns: table => new
                {
                    id_impacto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_descripcion_impacto = table.Column<string>(type: "varchar", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_impacto", x => x.id_impacto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cat_impacto");

            migrationBuilder.AlterColumn<string>(
                name: "ln_politica",
                table: "tb_cat_politica",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256);
        }
    }
}
