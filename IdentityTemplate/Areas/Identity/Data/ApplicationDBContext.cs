using IdentityTemplate.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityTemplate.Models.Catalogos;
using IdentityTemplate.Models.Intermedios;
using IdentityTemplate.Models.VariableSesguimiento;

namespace IdentityTemplate.Data;

public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
        
    }
    public DbSet<Politica> PoliticaAcciones { get; set; }
    public DbSet<NivelSeguimiento> NivelesSeguimiento { get; set; }
    public DbSet<TipoInstitucion> TipoInstituciones { get; set; }
    public DbSet<NivelResponsabilidad> NivelResponsabilidad { get; set; }
    public DbSet<PoliticaUsuario> PoliticaUsuario { get; set; }
    public DbSet<UnidadMeta> UnidadMeta { get; set; }
    public DbSet<TipoSoprte> TipoSoprtes { get; set; }
    public DbSet<AreaIncidencia> AreaIncidencia { get; set; }
    public DbSet<Impacto> Impacto { get; set; }
    public DbSet<IdentityUserRole<string>> RolUsuario { get; set; }
    public DbSet<EjeTematico> EjesTematicos { get; set; }
    public DbSet<LineaEstrategica> LineasEstrategicas { get; set; }
    public DbSet<Accion> Acciones { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Identity Tables
        builder.Entity<ApplicationUser>(b =>
        {
            b.ToTable("tb_usuario");

            b.HasKey(u => u.Id).HasName("id_ln_usuario");

            b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("idx01_usuario").IsUnique();

            b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("idx02_usuario");

            b.Property(u => u.Id).HasColumnType("varchar")
                                 .HasMaxLength(256)
                                 .HasColumnName("id_ln_usuario").HasColumnOrder(1);

            b.Property(u => u.UserName).HasColumnType("varchar")
                                       .HasMaxLength(256)
                                       .HasColumnName("ln_usuario").HasColumnOrder(2);

            b.Property(u => u.NormalizedUserName).HasColumnType("varchar")
                                                 .HasMaxLength(256)
                                                 .HasColumnName("ln_usuario_normalizado").HasColumnOrder(3);

            b.Property(u => u.Nombre).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_nombre_usuario").HasColumnOrder(4);

            b.Property(u => u.PrimerApellido).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_primer_apellido").HasColumnOrder(5);

            b.Property(u => u.SegundoApellido).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_segundo_apellido").HasColumnOrder(6);

            b.Property(u => u.CURP).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_curp").HasColumnOrder(7);

            b.Property(u => u.Email).HasColumnType("varchar")
                                    .HasMaxLength(256).HasColumnName("ln_correo_laboral").HasColumnOrder(8);

            b.Property(u => u.NormalizedEmail).HasColumnType("varchar")
                                              .HasMaxLength(256).HasColumnName("ln_c_normalizado").HasColumnOrder(9);

            b.Property(u => u.EmailConfirmed).HasColumnType("boolean")
                                             .HasColumnName("ind_correo_confirmado").HasColumnOrder(10);

            b.Property(u => u.CorreoPersonal).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_correo_personal").HasColumnOrder(11);

            b.Property(u => u.PhoneNumber).HasColumnType("varchar").HasColumnName("ln_tel_laboral").HasColumnOrder(12);

            b.Property(u => u.TelefonoPersonal).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_tel_personal").HasColumnOrder(13);

            b.HasOne(t => t.TipoInstitucion).WithMany(u => u.Usuario).HasForeignKey(f => f.TipoInstitucionId)
             .HasConstraintName("fk_usuario_institucion");

            b.Property(u => u.TipoInstitucionId).HasColumnName("fk_usuario_institucion");

            b.HasIndex(u => u.TipoInstitucionId).HasDatabaseName("idx05_usuario");

            b.Property(u => u.NombreInstitucion).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_nombre_institucion").HasColumnOrder(15);

            b.Property(u => u.CargoLaboral).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_cargo_laboral").HasColumnOrder(16);

            b.HasOne(t => t.NivelSeguimiento).WithMany(u => u.Usuario).HasForeignKey(f => f.NivelSeguimientoId)
             .HasConstraintName("fk_usuario_nivel_seg").IsRequired(false);

            b.Property(u => u.NivelSeguimientoId).HasColumnName("fk_usuario_nivel_seg");

            b.HasIndex(u => u.NivelSeguimientoId).HasDatabaseName("idx04_usuario");

            #region Propiedad no usada por el momento
            //b.HasOne(t => t.NivelResponsabilidad).WithMany(u => u.Usuario).HasForeignKey(f => f.NivelResponsabilidadId)
            // .HasConstraintName("fk_usuario_nivel_resp").IsRequired(false);

            //b.Property(u => u.NivelResponsabilidadId).HasDefaultValue(null);
            //b.Ignore(u => u.NivelResponsabilidadId);
            #endregion

            b.Property(u => u.PasswordHash).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_hash_contrasenia").HasColumnOrder(18);

            b.Property(u => u.SecurityStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_security_stamp").HasColumnOrder(19);

            b.Property(u => u.ConcurrencyStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_concurrency_stamp").HasColumnOrder(20);

            b.Ignore(u => u.PhoneNumberConfirmed);

            b.Property(u => u.TwoFactorEnabled).HasColumnType("boolean").HasColumnName("ind_two_factor_enabled").HasColumnOrder(21);

            b.Ignore(u => u.LockoutEnd);

            b.Property(u => u.LockoutEnabled).HasColumnType("boolean").HasColumnName("ind_bloqueo_habilitado").HasColumnOrder(22);

            b.Property(u => u.AccessFailedCount).HasColumnName("nu_num_acceso_fallido").HasColumnOrder(23);

        });

        builder.Entity<IdentityRole>(b =>
        {

            b.ToTable("tb_rol");

            b.HasKey(r => r.Id).HasName("id_ln_nivel_respon");

            b.HasIndex(r => r.Name).HasDatabaseName("idx01_rol");

            b.Property(r => r.Id).HasColumnType("varchar").HasMaxLength(256).HasColumnName("id_nivel_responsabilidad");
            b.Property(r => r.Name).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_nombre_nivel_resp");
            b.Property(r => r.NormalizedName).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_n_nivel_normalizado");
            b.Property(r => r.ConcurrencyStamp).HasColumnType("varchar").HasMaxLength(256);

        });

        builder.Entity<IdentityRoleClaim<string>>(b =>
        {

            b.ToTable("tb_r_rol_claim");

            b.HasKey(r => r.Id).HasName("id_ln_rol");

            b.HasIndex(r => r.RoleId).HasDatabaseName("idx01_rol_claim");

            b.Property(rc => rc.RoleId).HasColumnType("varchar").HasMaxLength(256);
            b.Property(rc => rc.ClaimType).HasColumnType("varchar").HasMaxLength(256);
            b.Property(rc => rc.ClaimValue).HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.ToTable("tb_r_usuario_claim");

            b.HasKey(uc => uc.Id).HasName("id_ln_usuario_claim");

            b.HasIndex(u => u.UserId).HasDatabaseName("idx01_usuario_claim");

            b.Property(uc => uc.UserId).HasColumnType("varchar").HasMaxLength(256);
            b.Property(uc => uc.ClaimValue).HasColumnType("varchar").HasMaxLength(256);
            b.Property(uc => uc.ClaimType).HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.ToTable("tb_r_usuario_sesion");

            b.HasKey(l => new { l.LoginProvider, l.ProviderKey }).HasName("id_ln_usuario_sesion");

            b.HasIndex(u => u.UserId).HasDatabaseName("idx01_usuario_sesion");

            b.Property(ul => ul.LoginProvider).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ul => ul.ProviderKey).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ul => ul.ProviderDisplayName).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ul => ul.UserId).HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<IdentityUserRole<string>>(b =>
        {
            b.ToTable("tb_r_usuario_rol");

            b.HasIndex(ur => ur.RoleId).HasDatabaseName("idx01_usuario_rol");

            b.Property(ur => ur.UserId).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ur => ur.RoleId).HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<IdentityUserToken<string>>(b =>
        {
            b.ToTable("tb_r_usuario_llave");

            b.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name }).HasName("id_ln_usuario_llave");

            b.HasIndex(ut => ut.UserId).HasDatabaseName("idx01_usuario_llave");

            b.Property(ut => ut.LoginProvider).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ut => ut.Name).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ut => ut.Value).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ut => ut.UserId).HasColumnType("varchar").HasMaxLength(256);
        });
        #endregion Identity tables

        #region Tablas catalogos
        builder.Entity<TipoInstitucion>(b =>
        {
            b.ToTable("tb_cat_tipo_institucion");

            b.HasKey(ti => ti.TipoInstitucionId).HasName("id_n_tipo_institucion");

            b.Property(ti => ti.TipoInstitucionId).HasColumnName("id_n_tipo_institucion").UseIdentityByDefaultColumn();

            b.HasIndex(ti => ti.NombreDeInstitucion).HasDatabaseName("idx01_tipo_institucion").IsUnique();

            b.Property(ti => ti.NombreDeInstitucion).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_institucion");
        });

        builder.Entity<NivelSeguimiento>(b =>
        {
            b.ToTable("tb_cat_nivel_seguimiento");

            b.HasKey(ns => ns.NivelSeguimientoId).HasName("id_n_nivel_seguimiento");

            b.Property(ns => ns.NivelSeguimientoId).HasColumnName("id_n_nivel_seguimiento").UseIdentityByDefaultColumn();

            b.HasIndex(ns => ns.NivelDeSeguimiento).HasDatabaseName("idx01_nivel_seguimiento").IsUnique();

            b.Property(ns => ns.NivelDeSeguimiento).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_nivel");
        });

        builder.Entity<Politica>(b =>
        {
            b.ToTable("tb_cat_politica");

            b.HasKey(pa => pa.PoliticaId).HasName("id_n_politica");

            b.Property(pa => pa.PoliticaId).HasColumnName("id_n_politica").UseIdentityByDefaultColumn();

            b.HasIndex(pa => pa.NombrePolitica)
             .HasDatabaseName("idx01_politica").IsUnique();

            b.Property(pa => pa.NombrePolitica)
             .HasColumnType("varchar")
             .HasMaxLength(256).HasColumnName("ln_politica");
        });

        List<NivelResponsabilidad> nivelesResponsabilidad = new List<NivelResponsabilidad>();

        nivelesResponsabilidad.Add(new NivelResponsabilidad { NivelResponsabilidadId = 1, NivelDeResponsabilidad = "Validador" });

        nivelesResponsabilidad.Add(new NivelResponsabilidad { NivelResponsabilidadId = 2, NivelDeResponsabilidad = "Ejecutor" });

        builder.Entity<NivelResponsabilidad>(b =>
        {
            b.ToTable("tb_cat_nivel_resp");

            b.HasKey(nr => nr.NivelResponsabilidadId).HasName("id_n_nivel_respon");

            b.Property(nr => nr.NivelResponsabilidadId).HasColumnName("id_n_nivel_respon").UseIdentityByDefaultColumn();

            b.Property(nr => nr.NivelDeResponsabilidad).HasColumnName("ln_nombre").HasMaxLength(256);

            b.HasData(nivelesResponsabilidad);
        });

        builder.Entity<PoliticaUsuario>(b =>
        {
            b.ToTable("tb_cat_r_politica_usuario");

            b.HasKey(pu => new { pu.PoliticaId, pu.UsuarioId }).HasName("id_n_politica_usuario");

            b.HasIndex(pu => pu.PoliticaId).HasDatabaseName("idx01_politica_usuario");

            b.HasIndex(pu => pu.UsuarioId).HasDatabaseName("idx02_politica_usuario");

            b.HasOne(o => o.Politica).WithMany(m => m.PoliticaUsuario).HasForeignKey(f => f.PoliticaId).HasConstraintName("fk01_politica_usuario");
            b.HasOne(o => o.Usuario).WithMany(m => m.PoliticaUsuario).HasForeignKey(f => f.UsuarioId).HasConstraintName("fk02_politica_usuario");

            b.Property(pu => pu.PoliticaId).HasColumnName("id_n_politica").UseIdentityByDefaultColumn();
            b.Property(pu => pu.UsuarioId).HasColumnName("id_ln_usuario").HasColumnType("varchar");

        });
        #endregion Tablas catalogos

        #region Variables de seguimiento
        builder.Entity<UnidadMeta>(b =>
        {
            b.ToTable("tb_cat_unidad_meta");

            b.HasKey(um => um.Id).HasName("id_n_unidad_meta");

            b.Property(um => um.Id).HasColumnName("id_n_unidad_meta").UseIdentityByDefaultColumn();
            b.Property(um => um.Nombre).HasColumnName("ln_nombre_unidad_meta").HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<TipoSoprte>(b =>
        {
            b.ToTable("tb_cat_tipo_soporte");

            b.HasKey(um => um.Id).HasName("id_n_tipo_soporte");

            b.Property(um => um.Id).HasColumnName("id_n_tipo_soporte").UseIdentityByDefaultColumn();
            b.Property(um => um.Nombre).HasColumnName("ln_nombre_tipo_soprte").HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<AreaIncidencia>(b =>
        {
            b.ToTable("tb_cat_area_incidencia");

            b.HasKey(um => um.Id).HasName("id_n_area_incidencia");

            b.Property(um => um.Id).HasColumnName("id_n_area_incidencia").UseIdentityByDefaultColumn();
            b.Property(um => um.Descripcion).HasColumnName("ln_descripcion_area").HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<Impacto>(b =>
        {
            b.ToTable("tb_cat_impacto");

            b.HasKey(um => um.Id).HasName("id_n_impacto");

            b.Property(um => um.Id).HasColumnName("id_n_impacto").UseIdentityByDefaultColumn();
            b.Property(um => um.Descripcion).HasColumnName("ln_descripcion_impacto").HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<EjeTematico>(b =>
        {
            b.ToTable("tb_cat_eje_tematico");

            b.HasKey(p => p.Id).HasName("id_n_eje_tematico");

            b.Property(p => p.Id).HasColumnName("id_n_eje_tematico").UseIdentityByDefaultColumn();
            b.Property(p => p.Nombre).HasColumnName("ln_descripcion_eje").HasColumnType("text");

            b.HasOne(o => o.Politica).WithMany(m => m.EjesTematicos).HasForeignKey(f => f.PoliticaId)
             .HasConstraintName("fk_politica_eje_tematico").IsRequired();

            b.Property(p => p.PoliticaId).HasColumnName("fk_politica_eje_tematico");

            b.HasIndex(p => p.PoliticaId).HasDatabaseName("idx01_eje_tematico");
        });

        builder.Entity<LineaEstrategica>(b =>
        {
            b.ToTable("tb_cat_linea_estrategica");

            b.HasKey(p => p.Id).HasName("id_n_linea_estrategica");

            b.Property(p => p.Id).HasColumnName("id_n_linea_estrategica").UseIdentityByDefaultColumn();
            b.Property(p => p.Nombre).HasColumnName("ln_desc_estrategia").HasColumnType("text");

            b.HasOne(o => o.EjeTematico).WithMany(m => m.LineasEstrategicas).HasForeignKey(f => f.EjeTematicoId)
             .HasConstraintName("fk_eje_tematico_lin_estrate").IsRequired();

            b.Property(p => p.EjeTematicoId).HasColumnName("fk_eje_tematico_lin_estrate");

            b.HasIndex(p => p.EjeTematicoId).HasDatabaseName("idx01_linea_estrateg");
        });


        builder.Entity<Accion>(b =>
        {
            b.ToTable("tb_cat_linea_estrategica");

            b.HasKey(p => p.Id).HasName("id_n_linea_estrategica");

            b.Property(p => p.Id).HasColumnName("id_n_linea_estrategica").UseIdentityByDefaultColumn();
            b.Property(p => p.Nombre).HasColumnName("ln_desc_estrategia").HasColumnType("text");

            b.HasOne(o => o.LineaEstrategica).WithMany(m => m.Acciones).HasForeignKey(f => f.LineaEstrategicaId)
             .HasConstraintName("fk_lin_estrategica_accion").IsRequired();

            b.Property(p => p.LineaEstrategicaId).HasColumnName("fk_eje_tematico_lin_estrate");

            b.HasIndex(p => p.LineaEstrategicaId).HasDatabaseName("idx01_linea_estrateg");
        });
        #endregion
    }


}
