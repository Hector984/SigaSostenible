using IdentityTemplate.Data;
using IdentityTemplate.Models.Catalogos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityTemplate.Areas.Identity.Data
{
    public class SeedData
    {
        #region Inicializacion
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDBContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDBContext>>()))
            {
                string admin = await EnsureUser(serviceProvider, testUserPw, "admin@admin.com");

                await EnsureRole(serviceProvider, admin, "Administrador Nacional");

                SeedDB(context);
            }

        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            ApplicationUser user = await userManager.FindByEmailAsync(UserName);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = UserName,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    Nombre = "Administrador",
                    PrimerApellido = "Administrador",
                    SegundoApellido = "Administrador",
                    CorreoPersonal = "admin@admin.com",
                    CURP = "admin",
                    NombreInstitucion = "Agricultura",
                    TelefonoPersonal = "5512345678",
                    PhoneNumber = "5512345678",
                    NivelResponsabilidadId = 1,
                    NivelSeguimientoId = 1,
                    TipoInstitucionId = 1
                };

                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("La contraseña no es muy segura.");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));

                #region Creando los roles 
                await roleManager.CreateAsync(new IdentityRole("Validador"));
                await roleManager.CreateAsync(new IdentityRole("Ejecutor"));
                #endregion
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            var roleUser = serviceProvider.GetService<RoleManager<IdentityUserRole<string>>>();


            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        #endregion

        #region seed database method
        public static void SeedDB(ApplicationDBContext context)
        {
            if (!context.TipoInstituciones.Any())
            {
                #region Inserta las instituciones
                context.TipoInstituciones.AddRange(

                    new TipoInstitucion
                    {
                        NombreDeInstitucion = Institucion.Federal.ToString()
                    },
                    new TipoInstitucion
                    {
                        NombreDeInstitucion = Institucion.Estatal.ToString()
                    },
                     new TipoInstitucion
                     {
                         NombreDeInstitucion = Institucion.Municipal.ToString()
                     },
                     new TipoInstitucion
                     {
                         NombreDeInstitucion = Institucion.Productores.ToString()
                     },
                     new TipoInstitucion
                     {
                         NombreDeInstitucion = Institucion.Academia.ToString()
                     },
                     new TipoInstitucion
                     {
                         NombreDeInstitucion = Institucion.SociedadCivil.ToString()
                     }
                 );
                #endregion
            } 
            
            if(!context.NivelesSeguimiento.Any())
            {
                #region Inserta los niveles de seguimiento
                context.NivelesSeguimiento.AddRange(

                    new NivelSeguimiento
                    {
                        NivelDeSeguimiento = Niveles.Nacional.ToString()
                    },

                    new NivelSeguimiento
                    {
                        NivelDeSeguimiento = Niveles.Estatal.ToString()
                    },
                     new NivelSeguimiento
                     {
                         NivelDeSeguimiento = Niveles.Regional.ToString()
                     },
                     new NivelSeguimiento
                     {
                         NivelDeSeguimiento = Niveles.Municipal.ToString()
                     },
                     new NivelSeguimiento
                     {
                         NivelDeSeguimiento = Niveles.Local.ToString()
                     }
                 );
                #endregion
            }


            if (!context.UnidadMeta.Any())
            {
                #region Catalogo Unidad de la Meta

                context.UnidadMeta.AddRange(

                    new UnidadMeta
                    {
                        Nombre = "Productores"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Hectáreas"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Informes-reportes"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Diagnósticos"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Reuniones"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Proyectos"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Catálogos"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Encuestas"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Areas piloto"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Personas capacitadas"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Grupos o redes"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Talleres"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Jardines-Huertos de polinizadores"
                    },
                    new UnidadMeta
                    {
                        Nombre = "Marcos normativos"
                    }
                 );

                #endregion
            }

            if(!context.TipoSoprtes.Any())
            {
                #region Tipo de soporte
                context.TipoSoprtes.AddRange(

                    new TipoSoprte
                    {
                        Nombre = "PDF"
                    },
                    new TipoSoprte
                    {
                        Nombre = "Word"
                    },
                    new TipoSoprte
                    {
                        Nombre = "Excel"
                    },
                    new TipoSoprte
                    {
                        Nombre = "PPT"
                    },
                    new TipoSoprte
                    {
                        Nombre = "Imagen"
                    },
                    new TipoSoprte
                    {
                        Nombre = "Video"
                    },
                    new TipoSoprte
                    {
                        Nombre = "Audio"
                    }
                 );
                #endregion
            }

            if(!context.AreaIncidencia.Any())
            {

            }

            if(!context.AreaIncidencia.Any())
            {
                #region Area incidencia
                context.AreaIncidencia.AddRange(

                   new AreaIncidencia
                   {
                       Descripcion = "Adaptación al Cambio Climático"
                   },
                   new AreaIncidencia
                   {
                       Descripcion = "Mitigación de gases de efecto invernadero"
                   },
                   new AreaIncidencia
                   {
                       Descripcion = "Producción sostenible"
                   },
                   new AreaIncidencia
                   {
                       Descripcion = "Conservación de la biodiversidad"
                   },
                   new AreaIncidencia
                   {
                       Descripcion = "Conservación del suelo"
                   },
                   new AreaIncidencia
                   {
                       Descripcion = "Conservación del agua"
                   },
                   new AreaIncidencia
                   {
                       Descripcion = "Otra"
                   }
                );
                #endregion
            }
            else
            {
                return;//La base de datos ya fue llenada
            }


            context.SaveChanges();

        }
        #endregion
    }
}
