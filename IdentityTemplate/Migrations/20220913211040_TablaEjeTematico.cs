using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class TablaEjeTematico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_usuario_institucion",
                table: "tb_usuario");

            migrationBuilder.DropForeignKey(
                name: "fk_usuario_nivel_resp",
                table: "tb_usuario");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_n_nivel_responsabilidad",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "n_nivel_responsabilidad",
                table: "tb_usuario");

            migrationBuilder.RenameColumn(
                name: "n_tipo_institucion",
                table: "tb_usuario",
                newName: "fk_usuario_institucion");

            migrationBuilder.RenameColumn(
                name: "n_nivel_seguimiento",
                table: "tb_usuario",
                newName: "fk_usuario_nivel_seg");

            migrationBuilder.RenameIndex(
                name: "IX_tb_usuario_n_tipo_institucion",
                table: "tb_usuario",
                newName: "idx05_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_tb_usuario_n_nivel_seguimiento",
                table: "tb_usuario",
                newName: "idx04_usuario");

            migrationBuilder.RenameColumn(
                name: "id_unidad_meta",
                table: "tb_cat_unidad_meta",
                newName: "id_n_unidad_meta");

            migrationBuilder.RenameColumn(
                name: "id_tipo_soporte",
                table: "tb_cat_tipo_soporte",
                newName: "id_n_tipo_soporte");

            migrationBuilder.RenameColumn(
                name: "idx01_tipo_institucion",
                table: "tb_cat_tipo_institucion",
                newName: "id_n_tipo_institucion");

            migrationBuilder.RenameIndex(
                name: "ln_institucion_ind",
                table: "tb_cat_tipo_institucion",
                newName: "idx01_tipo_institucion");

            migrationBuilder.RenameColumn(
                name: "id_politica",
                table: "tb_cat_politica",
                newName: "id_n_politica");

            migrationBuilder.RenameColumn(
                name: "id_nivel_seguimiento",
                table: "tb_cat_nivel_seguimiento",
                newName: "id_n_nivel_seguimiento");

            migrationBuilder.RenameColumn(
                name: "id_impacto",
                table: "tb_cat_impacto",
                newName: "id_n_impacto");

            migrationBuilder.RenameColumn(
                name: "id_area_incidencia",
                table: "tb_cat_area_incidencia",
                newName: "id_n_area_incidencia");

            migrationBuilder.AlterColumn<int>(
                name: "nu_num_acceso_fallido",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 23)
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<string>(
                name: "ln_security_stamp",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 19)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<string>(
                name: "ln_hash_contrasenia",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 18)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<string>(
                name: "ln_concurrency_stamp",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 20)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_two_factor_enabled",
                table: "tb_usuario",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_bloqueo_habilitado",
                table: "tb_usuario",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 22)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<int>(
                name: "fk_usuario_institucion",
                table: "tb_usuario",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "fk_usuario_nivel_seg",
                table: "tb_usuario",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "tb_cat_eje_tematico",
                columns: table => new
                {
                    id_n_eje_tematico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_descripcion_impacto = table.Column<string>(type: "text", nullable: true),
                    fk_politica_eje_tematico = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_eje_tematico", x => x.id_n_eje_tematico);
                    table.ForeignKey(
                        name: "fk_politica_eje_tematico",
                        column: x => x.fk_politica_eje_tematico,
                        principalTable: "tb_cat_politica",
                        principalColumn: "id_n_politica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx01_eje_tematico",
                table: "tb_cat_eje_tematico",
                column: "fk_politica_eje_tematico");

            migrationBuilder.AddForeignKey(
                name: "fk_usuario_institucion",
                table: "tb_usuario",
                column: "fk_usuario_institucion",
                principalTable: "tb_cat_tipo_institucion",
                principalColumn: "id_n_tipo_institucion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_usuario_institucion",
                table: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_cat_eje_tematico");

            migrationBuilder.RenameColumn(
                name: "fk_usuario_nivel_seg",
                table: "tb_usuario",
                newName: "n_nivel_seguimiento");

            migrationBuilder.RenameColumn(
                name: "fk_usuario_institucion",
                table: "tb_usuario",
                newName: "n_tipo_institucion");

            migrationBuilder.RenameIndex(
                name: "idx05_usuario",
                table: "tb_usuario",
                newName: "IX_tb_usuario_n_tipo_institucion");

            migrationBuilder.RenameIndex(
                name: "idx04_usuario",
                table: "tb_usuario",
                newName: "IX_tb_usuario_n_nivel_seguimiento");

            migrationBuilder.RenameColumn(
                name: "id_n_unidad_meta",
                table: "tb_cat_unidad_meta",
                newName: "id_unidad_meta");

            migrationBuilder.RenameColumn(
                name: "id_n_tipo_soporte",
                table: "tb_cat_tipo_soporte",
                newName: "id_tipo_soporte");

            migrationBuilder.RenameColumn(
                name: "id_n_tipo_institucion",
                table: "tb_cat_tipo_institucion",
                newName: "idx01_tipo_institucion");

            migrationBuilder.RenameIndex(
                name: "idx01_tipo_institucion",
                table: "tb_cat_tipo_institucion",
                newName: "ln_institucion_ind");

            migrationBuilder.RenameColumn(
                name: "id_n_politica",
                table: "tb_cat_politica",
                newName: "id_politica");

            migrationBuilder.RenameColumn(
                name: "id_n_nivel_seguimiento",
                table: "tb_cat_nivel_seguimiento",
                newName: "id_nivel_seguimiento");

            migrationBuilder.RenameColumn(
                name: "id_n_impacto",
                table: "tb_cat_impacto",
                newName: "id_impacto");

            migrationBuilder.RenameColumn(
                name: "id_n_area_incidencia",
                table: "tb_cat_area_incidencia",
                newName: "id_area_incidencia");

            migrationBuilder.AlterColumn<int>(
                name: "nu_num_acceso_fallido",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 24)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<string>(
                name: "ln_security_stamp",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 20)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<string>(
                name: "ln_hash_contrasenia",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 19)
                .OldAnnotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<string>(
                name: "ln_concurrency_stamp",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 21)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_two_factor_enabled",
                table: "tb_usuario",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 22)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_bloqueo_habilitado",
                table: "tb_usuario",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 23)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<int>(
                name: "n_nivel_seguimiento",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "n_tipo_institucion",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "n_nivel_responsabilidad",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_n_nivel_responsabilidad",
                table: "tb_usuario",
                column: "n_nivel_responsabilidad");

            migrationBuilder.AddForeignKey(
                name: "fk_usuario_institucion",
                table: "tb_usuario",
                column: "n_tipo_institucion",
                principalTable: "tb_cat_tipo_institucion",
                principalColumn: "idx01_tipo_institucion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_usuario_nivel_resp",
                table: "tb_usuario",
                column: "n_nivel_responsabilidad",
                principalTable: "tb_cat_nivel_resp",
                principalColumn: "id_n_nivel_respon");
        }
    }
}
