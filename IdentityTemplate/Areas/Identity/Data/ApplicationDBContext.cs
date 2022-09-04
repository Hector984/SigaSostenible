using IdentityTemplate.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityTemplate.Models.Catalogs;

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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Identity Tables
        builder.Entity<ApplicationUser>(b =>
        {
            b.ToTable("tb_usuario");

            b.Property(u => u.Id).HasColumnType("varchar")
                                 .HasMaxLength(256)
                                 .HasColumnName("id_usuario");

            b.Property(u => u.UserName).HasColumnType("varchar")
                                       .HasMaxLength(256)
                                       .HasColumnName("ln_nombre_usuario");

            b.Property(u => u.NormalizedUserName).HasColumnType("varchar")
                                                 .HasMaxLength(256)
                                                 .HasColumnName("ln_n_usuario_normalizado");

            b.Property(u => u.Email).HasColumnType("varchar")
                                    .HasMaxLength(256).HasColumnName("ln_correo_laboral");

            b.Property(u => u.NormalizedEmail).HasColumnType("varchar")
                                              .HasMaxLength(256).HasColumnName("ln_c_normalizado");

            b.Property(u => u.EmailConfirmed).HasColumnType("boolean")
                                             .HasColumnName("ind_correo_confirmado");

            b.Property(u => u.PasswordHash).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_hash_contrasenia");

            b.Property(u => u.SecurityStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_security_stamp");

            b.Property(u => u.ConcurrencyStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_concurrency_stamp");

            b.Property(u => u.PhoneNumber).HasColumnType("varchar").HasColumnName("ln_tel_laboral");

            b.Property(u => u.PhoneNumberConfirmed).HasColumnType("boolean").HasColumnName("ind_tel_laboral_conf");

            b.Property(u => u.TwoFactorEnabled).HasColumnType("boolean").HasColumnName("ind_two_factor_enabled");

            //b.Property(u => u.LockoutEnd).HasColumnType("timestamp").HasColumnName("dtm_lockout_end").IsRequired(false);
            b.Ignore(u => u.LockoutEnd);

            b.Property(u => u.LockoutEnabled).HasColumnType("boolean").HasColumnName("ind_bloqueo_habilitado");

            b.Property(u => u.AccessFailedCount).HasColumnName("nu_num_acceso_fallido");

        });

        builder.Entity<IdentityRole>(b =>
        {

            b.Property(r => r.Id).HasColumnType("varchar").HasMaxLength(256).HasColumnName("id_nivel_responsabilidad");
            b.Property(r => r.Name).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_nombre_nivel_resp");
            b.Property(r => r.NormalizedName).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_n_nivel_normalizado");
            b.Property(r => r.ConcurrencyStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("");

        });

        builder.Entity<IdentityRoleClaim<string>>(b =>
        {
            b.Property(rc => rc.RoleId).HasColumnType("varchar").HasMaxLength(256);
            b.Property(rc => rc.ClaimType).HasColumnType("varchar").HasMaxLength(256);
            b.Property(rc => rc.ClaimValue).HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.Property(uc => uc.UserId).HasColumnType("varchar").HasMaxLength(256);
            b.Property(uc => uc.ClaimValue).HasColumnType("varchar").HasMaxLength(256);
            b.Property(uc => uc.ClaimType).HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.Property(ul => ul.LoginProvider).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ul => ul.ProviderKey).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ul => ul.ProviderDisplayName).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ul => ul.UserId).HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<IdentityUserRole<string>>(b =>
        {
            b.Property(ur => ur.UserId).HasColumnType("varchar").HasMaxLength(256);
            b.Property(ur => ur.RoleId).HasColumnType("varchar").HasMaxLength(256);
        });

        builder.Entity<IdentityUserToken<string>>(b =>
        {
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

            b.HasKey(ti => ti.TipoInstitucionId);

            b.Property(ti => ti.TipoInstitucionId).HasColumnName("id_tipo_institucion").UseIdentityByDefaultColumn();

            b.HasIndex(ti => ti.Institucion).HasDatabaseName("ln_institucion_ind").IsUnique();

            b.Property(ti => ti.Institucion).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_institucion");
        });

        builder.Entity<NivelSeguimiento>(b =>
        {
            b.ToTable("tb_cat_nivel_seguimiento");

            b.HasKey(ns => ns.NivelSeguimientoId);

            b.Property(ns => ns.NivelSeguimientoId).HasColumnName("id_nivel_seguimiento").UseIdentityByDefaultColumn();

            b.HasIndex(ns => ns.Nivel).HasDatabaseName("ln_nivel_indice").IsUnique();

            b.Property(ns => ns.Nivel).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_nivel");
        });

        builder.Entity<Politica>(b =>
        {
            b.ToTable("tb_cat_politica");

            b.HasKey(pa => pa.PoliticaId);

            b.Property(pa => pa.PoliticaId).HasColumnName("id_politica").UseIdentityByDefaultColumn();

            b.HasIndex(pa => pa.NombrePolitica)
             .HasDatabaseName("ln_politica_ind").IsUnique();

            b.Property(pa => pa.NombrePolitica)
             .HasColumnType("varchar")
             .HasMaxLength(256).HasColumnName("ln_politica");
        });
        #endregion Tablas catalogos
    }


}
