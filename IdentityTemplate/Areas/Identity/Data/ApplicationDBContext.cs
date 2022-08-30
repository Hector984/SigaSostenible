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
    public DbSet<PoliticaAccion> PoliticaAcciones { get; set; }
    public DbSet<TipoInstitucion> TipoInstituciones { get; set; }
    public DbSet<NivelSeguimiento> NivelesSeguimiento { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Identity Tables
        builder.Entity<ApplicationUser>(b =>
        {

            b.Property(u => u.Id).HasColumnType("varchar").HasMaxLength(256).HasColumnName("id_user");
            b.Property(u => u.UserName).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_user_name");
            b.Property(u => u.NormalizedUserName).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_normalized_user_name");
            b.Property(u => u.Email).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_email");
            b.Property(u => u.NormalizedEmail).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_normalized_email");
            b.Property(u => u.EmailConfirmed).HasColumnType("boolean").HasColumnName("ind_email_confirmed");
            b.Property(u => u.PasswordHash).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_password_hash");
            b.Property(u => u.SecurityStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_security_stamp");
            b.Property(u => u.ConcurrencyStamp).HasColumnType("varchar").HasMaxLength(256).HasColumnName("ln_concurrency_stamp");
            b.Property(u => u.PhoneNumber).HasColumnType("varchar").HasColumnName("ln_phone_number");
            b.Property(u => u.PhoneNumberConfirmed).HasColumnType("boolean").HasColumnName("ind_phone_number_confirmed");
            b.Property(u => u.TwoFactorEnabled).HasColumnType("boolean").HasColumnName("ind_two_factor_enabled");
            //b.Property(u => u.LockoutEnd).HasColumnType("timestamp").HasColumnName("dtm_lockout_end").IsRequired(false);
            b.Ignore(u => u.LockoutEnd);
            b.Property(u => u.LockoutEnabled).HasColumnType("boolean").HasColumnName("ind_lockout_enabled");
            b.Property(u => u.AccessFailedCount).HasColumnName("nu_access_failed_count");

        });

        builder.Entity<IdentityRole>(b =>
        {

            b.Property(r => r.Id).HasColumnType("varchar").HasMaxLength(256);
            b.Property(r => r.Name).HasColumnType("varchar").HasMaxLength(256);
            b.Property(r => r.NormalizedName).HasColumnType("varchar").HasMaxLength(256);
            b.Property(r => r.ConcurrencyStamp).HasColumnType("varchar").HasMaxLength(256);

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
            b.Property(ti => ti.TipoInstitucionId).HasColumnType("varchar");
            b.Property(ti => ti.Institucion).HasColumnType("varchar");
        });

        builder.Entity<NivelSeguimiento>(b =>
        {
            b.Property(ns => ns.NivelSeguimientoId).HasColumnType("varchar");
            b.Property(ns => ns.Nivel).HasColumnType("varchar");
        });

        builder.Entity<PoliticaAccion>(b =>
        {
            b.Property(pa => pa.PoliticaAccionId).HasColumnType("varchar");
            b.Property(pa => pa.NombrePoliticaAccion).HasColumnType("varchar");
        });
        #endregion Tablas catalogos
    }


}
