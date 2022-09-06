using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class TablaPoliticaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ln_usuario",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ln_segundo_apellido",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ln_primer_apellido",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ln_nombre_usuario",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ln_curp",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tb_cat_r_politica_usuario",
                columns: table => new
                {
                    id_ln_usuario = table.Column<string>(type: "varchar", nullable: false),
                    id_n_politica = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_politica_usuario", x => new { x.id_n_politica, x.id_ln_usuario });
                    table.ForeignKey(
                        name: "fk01_politica_usuario",
                        column: x => x.id_n_politica,
                        principalTable: "tb_cat_politica",
                        principalColumn: "id_politica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk02_politica_usuario",
                        column: x => x.id_ln_usuario,
                        principalTable: "tb_usuario",
                        principalColumn: "id_ln_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx01_politica_usuario",
                table: "tb_cat_r_politica_usuario",
                column: "id_n_politica");

            migrationBuilder.CreateIndex(
                name: "idx02_politica_usuario",
                table: "tb_cat_r_politica_usuario",
                column: "id_ln_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cat_r_politica_usuario");

            migrationBuilder.AlterColumn<string>(
                name: "ln_usuario",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ln_segundo_apellido",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ln_primer_apellido",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ln_nombre_usuario",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ln_curp",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256);
        }
    }
}
