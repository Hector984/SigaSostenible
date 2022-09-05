using IdentityTemplate.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityTemplate.Models.Catalogos;

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

            b.Property(u => u.TipoInstitucionId).HasDefaultValue(null);

            b.Property(u => u.NombreInstitucion).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_nombre_institucion").HasColumnOrder(15);

            b.Property(u => u.CargoLaboral).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_cargo_laboral").HasColumnOrder(16);

            b.HasOne(t => t.NivelSeguimiento).WithMany(u => u.Usuario).HasForeignKey(f => f.NivelSeguimientoId)
             .HasConstraintName("fk_usuario_nivel_seg").IsRequired(false);

            b.Property(u => u.NivelSeguimientoId).HasDefaultValue(null);

            b.HasOne(t => t.NivelResponsabilidad).WithMany(u => u.Usuario).HasForeignKey(f => f.NivelResponsabilidadId)
             .HasConstraintName("fk_usuario_nivel_resp").IsRequired(false);

            b.Property(u => u.NivelResponsabilidadId).HasDefaultValue(null);

            b.Property(u => u.PasswordHash).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_hash_contrasenia").HasColumnOrder(19);

            b.Property(u => u.SecurityStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_security_stamp").HasColumnOrder(20);

            b.Property(u => u.ConcurrencyStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_concurrency_stamp").HasColumnOrder(21);

            b.Ignore(u => u.PhoneNumberConfirmed);

            b.Property(u => u.TwoFactorEnabled).HasColumnType("boolean").HasColumnName("ind_two_factor_enabled").HasColumnOrder(22);

            b.Ignore(u => u.LockoutEnd);

            b.Property(u => u.LockoutEnabled).HasColumnType("boolean").HasColumnName("ind_bloqueo_habilitado").HasColumnOrder(23);

            b.Property(u => u.AccessFailedCount).HasColumnName("nu_num_acceso_fallido").HasColumnOrder(24);

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

            b.Property(ti => ti.TipoInstitucionId).HasColumnName("idx01_tipo_institucion").UseIdentityByDefaultColumn();

            b.HasIndex(ti => ti.NombreDeInstitucion).HasDatabaseName("ln_institucion_ind").IsUnique();

            b.Property(ti => ti.NombreDeInstitucion).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_institucion");
        });

        builder.Entity<NivelSeguimiento>(b =>
        {
            b.ToTable("tb_cat_nivel_seguimiento");

            b.HasKey(ns => ns.NivelSeguimientoId).HasName("id_n_nivel_seguimiento");

            b.Property(ns => ns.NivelSeguimientoId).HasColumnName("id_nivel_seguimiento").UseIdentityByDefaultColumn();

            b.HasIndex(ns => ns.NivelDeSeguimiento).HasDatabaseName("idx01_nivel_seguimiento").IsUnique();

            b.Property(ns => ns.NivelDeSeguimiento).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_nivel");
        });

        builder.Entity<Politica>(b =>
        {
            b.ToTable("tb_cat_politica");

            b.HasKey(pa => pa.PoliticaId).HasName("id_n_politica");

            b.Property(pa => pa.PoliticaId).HasColumnName("id_politica").UseIdentityByDefaultColumn();

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
        #endregion Tablas catalogos
    }


}
