using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IdentityTemplate.Migrations
{
    public partial class NuevosCamposEnElModeloUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "NivelesSeguimiento");

            migrationBuilder.DropTable(
                name: "PoliticaAcciones");

            migrationBuilder.DropTable(
                name: "TipoInstituciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "ind_phone_number_confirmed",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "tb_r_usuario_llave");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "tb_r_usuario_rol");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "tb_r_usuario_sesion");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "tb_r_usuario_claim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "tb_rol");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "tb_r_rol_claim");

            migrationBuilder.RenameColumn(
                name: "nu_access_failed_count",
                table: "tb_usuario",
                newName: "nu_num_acceso_fallido");

            migrationBuilder.RenameColumn(
                name: "ln_user_name",
                table: "tb_usuario",
                newName: "ln_usuario");

            migrationBuilder.RenameColumn(
                name: "ln_phone_number",
                table: "tb_usuario",
                newName: "ln_tel_laboral");

            migrationBuilder.RenameColumn(
                name: "ln_password_hash",
                table: "tb_usuario",
                newName: "ln_hash_contrasenia");

            migrationBuilder.RenameColumn(
                name: "ln_normalized_user_name",
                table: "tb_usuario",
                newName: "ln_usuario_normalizado");

            migrationBuilder.RenameColumn(
                name: "ln_normalized_email",
                table: "tb_usuario",
                newName: "ln_c_normalizado");

            migrationBuilder.RenameColumn(
                name: "ln_email",
                table: "tb_usuario",
                newName: "ln_correo_laboral");

            migrationBuilder.RenameColumn(
                name: "ind_lockout_enabled",
                table: "tb_usuario",
                newName: "ind_bloqueo_habilitado");

            migrationBuilder.RenameColumn(
                name: "ind_email_confirmed",
                table: "tb_usuario",
                newName: "ind_correo_confirmado");

            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "tb_usuario",
                newName: "id_ln_usuario");

            migrationBuilder.RenameIndex(
                name: "UserNameIndex",
                table: "tb_usuario",
                newName: "idx01_usuario");

            migrationBuilder.RenameIndex(
                name: "EmailIndex",
                table: "tb_usuario",
                newName: "idx02_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "tb_r_usuario_rol",
                newName: "idx01_usuario_rol");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "tb_r_usuario_sesion",
                newName: "idx01_usuario_sesion");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "tb_r_usuario_claim",
                newName: "idx01_usuario_claim");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "tb_rol",
                newName: "ln_n_nivel_normalizado");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_rol",
                newName: "ln_nombre_nivel_resp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_rol",
                newName: "id_nivel_responsabilidad");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "tb_r_rol_claim",
                newName: "idx01_rol_claim");

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
                .Annotation("Relational:ColumnOrder", 20);

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
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_two_factor_enabled",
                table: "tb_usuario",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<int>(
                name: "nu_num_acceso_fallido",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<string>(
                name: "ln_usuario",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "ln_tel_laboral",
                table: "tb_usuario",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 12);

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
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<string>(
                name: "ln_usuario_normalizado",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "ln_c_normalizado",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "ln_correo_laboral",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_bloqueo_habilitado",
                table: "tb_usuario",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_correo_confirmado",
                table: "tb_usuario",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "id_ln_usuario",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<string>(
                name: "ln_cargo_laboral",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "ln_correo_personal",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<string>(
                name: "ln_curp",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<string>(
                name: "ln_nombre_institucion",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "ln_nombre_usuario",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<string>(
                name: "ln_primer_apellido",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<string>(
                name: "ln_segundo_apellido",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "ln_tel_personal",
                table: "tb_usuario",
                type: "varchar",
                maxLength: 256,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<int>(
                name: "n_nivel_responsabilidad",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AddColumn<int>(
                name: "n_nivel_seguimiento",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<int>(
                name: "n_tipo_institucion",
                table: "tb_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddPrimaryKey(
                name: "id_ln_usuario_llave",
                table: "tb_r_usuario_llave",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "id_ln_usuario",
                table: "tb_usuario",
                column: "id_ln_usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_r_usuario_rol",
                table: "tb_r_usuario_rol",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "id_ln_usuario_sesion",
                table: "tb_r_usuario_sesion",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "id_ln_usuario_claim",
                table: "tb_r_usuario_claim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "id_ln_nivel_respon",
                table: "tb_rol",
                column: "id_nivel_responsabilidad");

            migrationBuilder.AddPrimaryKey(
                name: "id_ln_rol",
                table: "tb_r_rol_claim",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tb_cat_nivel_resp",
                columns: table => new
                {
                    id_n_nivel_respon = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_nombre = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_nivel_respon", x => x.id_n_nivel_respon);
                });

            migrationBuilder.CreateTable(
                name: "tb_cat_nivel_seguimiento",
                columns: table => new
                {
                    id_nivel_seguimiento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_nivel = table.Column<string>(type: "varchar", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_nivel_seguimiento", x => x.id_nivel_seguimiento);
                });

            migrationBuilder.CreateTable(
                name: "tb_cat_politica",
                columns: table => new
                {
                    id_politica = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_politica = table.Column<string>(type: "varchar", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_politica", x => x.id_politica);
                });

            migrationBuilder.CreateTable(
                name: "tb_cat_tipo_institucion",
                columns: table => new
                {
                    idx01_tipo_institucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ln_institucion = table.Column<string>(type: "varchar", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_n_tipo_institucion", x => x.idx01_tipo_institucion);
                });

            migrationBuilder.InsertData(
                table: "tb_cat_nivel_resp",
                columns: new[] { "id_n_nivel_respon", "ln_nombre" },
                values: new object[,]
                {
                    { 1, "Validador" },
                    { 2, "Ejecutor" }
                });

            migrationBuilder.CreateIndex(
                name: "idx01_usuario_llave",
                table: "tb_r_usuario_llave",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_n_nivel_responsabilidad",
                table: "tb_usuario",
                column: "n_nivel_responsabilidad");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_n_nivel_seguimiento",
                table: "tb_usuario",
                column: "n_nivel_seguimiento");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_n_tipo_institucion",
                table: "tb_usuario",
                column: "n_tipo_institucion");

            migrationBuilder.CreateIndex(
                name: "idx01_rol",
                table: "tb_rol",
                column: "ln_nombre_nivel_resp");

            migrationBuilder.CreateIndex(
                name: "idx01_nivel_seguimiento",
                table: "tb_cat_nivel_seguimiento",
                column: "ln_nivel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx01_politica",
                table: "tb_cat_politica",
                column: "ln_politica",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ln_institucion_ind",
                table: "tb_cat_tipo_institucion",
                column: "ln_institucion",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_r_rol_claim_tb_rol_RoleId",
                table: "tb_r_rol_claim",
                column: "RoleId",
                principalTable: "tb_rol",
                principalColumn: "id_nivel_responsabilidad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_r_usuario_claim_tb_usuario_UserId",
                table: "tb_r_usuario_claim",
                column: "UserId",
                principalTable: "tb_usuario",
                principalColumn: "id_ln_usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_r_usuario_llave_tb_usuario_UserId",
                table: "tb_r_usuario_llave",
                column: "UserId",
                principalTable: "tb_usuario",
                principalColumn: "id_ln_usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_r_usuario_rol_tb_rol_RoleId",
                table: "tb_r_usuario_rol",
                column: "RoleId",
                principalTable: "tb_rol",
                principalColumn: "id_nivel_responsabilidad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_r_usuario_rol_tb_usuario_UserId",
                table: "tb_r_usuario_rol",
                column: "UserId",
                principalTable: "tb_usuario",
                principalColumn: "id_ln_usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_r_usuario_sesion_tb_usuario_UserId",
                table: "tb_r_usuario_sesion",
                column: "UserId",
                principalTable: "tb_usuario",
                principalColumn: "id_ln_usuario",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "fk_usuario_nivel_seg",
                table: "tb_usuario",
                column: "n_nivel_seguimiento",
                principalTable: "tb_cat_nivel_seguimiento",
                principalColumn: "id_nivel_seguimiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_r_rol_claim_tb_rol_RoleId",
                table: "tb_r_rol_claim");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_r_usuario_claim_tb_usuario_UserId",
                table: "tb_r_usuario_claim");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_r_usuario_llave_tb_usuario_UserId",
                table: "tb_r_usuario_llave");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_r_usuario_rol_tb_rol_RoleId",
                table: "tb_r_usuario_rol");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_r_usuario_rol_tb_usuario_UserId",
                table: "tb_r_usuario_rol");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_r_usuario_sesion_tb_usuario_UserId",
                table: "tb_r_usuario_sesion");

            migrationBuilder.DropForeignKey(
                name: "fk_usuario_institucion",
                table: "tb_usuario");

            migrationBuilder.DropForeignKey(
                name: "fk_usuario_nivel_resp",
                table: "tb_usuario");

            migrationBuilder.DropForeignKey(
                name: "fk_usuario_nivel_seg",
                table: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_cat_nivel_resp");

            migrationBuilder.DropTable(
                name: "tb_cat_nivel_seguimiento");

            migrationBuilder.DropTable(
                name: "tb_cat_politica");

            migrationBuilder.DropTable(
                name: "tb_cat_tipo_institucion");

            migrationBuilder.DropPrimaryKey(
                name: "id_ln_usuario",
                table: "tb_usuario");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_n_nivel_responsabilidad",
                table: "tb_usuario");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_n_nivel_seguimiento",
                table: "tb_usuario");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_n_tipo_institucion",
                table: "tb_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "id_ln_nivel_respon",
                table: "tb_rol");

            migrationBuilder.DropIndex(
                name: "idx01_rol",
                table: "tb_rol");

            migrationBuilder.DropPrimaryKey(
                name: "id_ln_usuario_sesion",
                table: "tb_r_usuario_sesion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_r_usuario_rol",
                table: "tb_r_usuario_rol");

            migrationBuilder.DropPrimaryKey(
                name: "id_ln_usuario_llave",
                table: "tb_r_usuario_llave");

            migrationBuilder.DropIndex(
                name: "idx01_usuario_llave",
                table: "tb_r_usuario_llave");

            migrationBuilder.DropPrimaryKey(
                name: "id_ln_usuario_claim",
                table: "tb_r_usuario_claim");

            migrationBuilder.DropPrimaryKey(
                name: "id_ln_rol",
                table: "tb_r_rol_claim");

            migrationBuilder.DropColumn(
                name: "ln_cargo_laboral",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "ln_correo_personal",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "ln_curp",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "ln_nombre_institucion",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "ln_nombre_usuario",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "ln_primer_apellido",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "ln_segundo_apellido",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "ln_tel_personal",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "n_nivel_responsabilidad",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "n_nivel_seguimiento",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "n_tipo_institucion",
                table: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "tb_rol",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "tb_r_usuario_sesion",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "tb_r_usuario_rol",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "tb_r_usuario_llave",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "tb_r_usuario_claim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "tb_r_rol_claim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameColumn(
                name: "nu_num_acceso_fallido",
                table: "AspNetUsers",
                newName: "nu_access_failed_count");

            migrationBuilder.RenameColumn(
                name: "ln_usuario_normalizado",
                table: "AspNetUsers",
                newName: "ln_normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "ln_usuario",
                table: "AspNetUsers",
                newName: "ln_user_name");

            migrationBuilder.RenameColumn(
                name: "ln_tel_laboral",
                table: "AspNetUsers",
                newName: "ln_phone_number");

            migrationBuilder.RenameColumn(
                name: "ln_hash_contrasenia",
                table: "AspNetUsers",
                newName: "ln_password_hash");

            migrationBuilder.RenameColumn(
                name: "ln_correo_laboral",
                table: "AspNetUsers",
                newName: "ln_email");

            migrationBuilder.RenameColumn(
                name: "ln_c_normalizado",
                table: "AspNetUsers",
                newName: "ln_normalized_email");

            migrationBuilder.RenameColumn(
                name: "ind_correo_confirmado",
                table: "AspNetUsers",
                newName: "ind_email_confirmed");

            migrationBuilder.RenameColumn(
                name: "ind_bloqueo_habilitado",
                table: "AspNetUsers",
                newName: "ind_lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "id_ln_usuario",
                table: "AspNetUsers",
                newName: "id_user");

            migrationBuilder.RenameIndex(
                name: "idx02_usuario",
                table: "AspNetUsers",
                newName: "EmailIndex");

            migrationBuilder.RenameIndex(
                name: "idx01_usuario",
                table: "AspNetUsers",
                newName: "UserNameIndex");

            migrationBuilder.RenameColumn(
                name: "ln_nombre_nivel_resp",
                table: "AspNetRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ln_n_nivel_normalizado",
                table: "AspNetRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "id_nivel_responsabilidad",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "idx01_usuario_sesion",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "idx01_usuario_rol",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "idx01_usuario_claim",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "idx01_rol_claim",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "ln_security_stamp",
                table: "AspNetUsers",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<string>(
                name: "ln_concurrency_stamp",
                table: "AspNetUsers",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_two_factor_enabled",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<int>(
                name: "nu_access_failed_count",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<string>(
                name: "ln_normalized_user_name",
                table: "AspNetUsers",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "ln_user_name",
                table: "AspNetUsers",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "ln_phone_number",
                table: "AspNetUsers",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<string>(
                name: "ln_password_hash",
                table: "AspNetUsers",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<string>(
                name: "ln_email",
                table: "AspNetUsers",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "ln_normalized_email",
                table: "AspNetUsers",
                type: "varchar",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_email_confirmed",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<bool>(
                name: "ind_lockout_enabled",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<string>(
                name: "id_user",
                table: "AspNetUsers",
                type: "varchar",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 256)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<bool>(
                name: "ind_phone_number_confirmed",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "id_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NivelesSeguimiento",
                columns: table => new
                {
                    NivelSeguimientoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nivel = table.Column<string>(type: "varchar", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelesSeguimiento", x => x.NivelSeguimientoId);
                });

            migrationBuilder.CreateTable(
                name: "PoliticaAcciones",
                columns: table => new
                {
                    PoliticaAccionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombrePoliticaAccion = table.Column<string>(type: "varchar", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticaAcciones", x => x.PoliticaAccionId);
                });

            migrationBuilder.CreateTable(
                name: "TipoInstituciones",
                columns: table => new
                {
                    TipoInstitucionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Institucion = table.Column<string>(type: "varchar", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInstituciones", x => x.TipoInstitucionId);
                });

            migrationBuilder.CreateIndex(
                name: "NivelIndex",
                table: "NivelesSeguimiento",
                column: "Nivel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NombrePoliticaAccionIndex",
                table: "PoliticaAcciones",
                column: "NombrePoliticaAccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Institucionindex",
                table: "TipoInstituciones",
                column: "Institucion",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
