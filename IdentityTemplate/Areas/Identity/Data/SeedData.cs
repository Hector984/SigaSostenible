﻿using IdentityTemplate.Data;
using IdentityTemplate.Models.Catalogs;
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

                await EnsureRole(serviceProvider, admin, "AdministradorNacional");

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
                    AccessFailedCount = 0
                };

                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
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
            //if (context.TipoInstituciones.Count() > 0)
            //{
            //    return;   // DB has been seeded
            //}

            #region Inserta las instituciones
            context.TipoInstituciones.AddRange(
           
                new TipoInstitucion
                {
                    Institucion = Institucion.Federal
                },
                new TipoInstitucion
                {
                    Institucion = Institucion.Estatal
                },
                 new TipoInstitucion
                 {
                     Institucion = Institucion.Municipal
                 },
                 new TipoInstitucion
                 {
                     Institucion = Institucion.Productores
                 },
                 new TipoInstitucion
                 {
                     Institucion = Institucion.Academia
                 },
                 new TipoInstitucion
                 {
                     Institucion = Institucion.SociedadCivil
                 }
             );
            #endregion


            //if (context.NivelesSeguimiento.Count() > 0)
            //{
            //    return;   // DB has been seeded
            //}

            #region Inserta los niveles de seguimiento
            context.NivelesSeguimiento.AddRange(
            
                new NivelSeguimiento
                {
                    Nivel = Niveles.Nacional
                },

                new NivelSeguimiento
                {
                    Nivel = Niveles.Estatal
                },
                 new NivelSeguimiento
                 {
                     Nivel = Niveles.Regional
                 },
                 new NivelSeguimiento
                 {
                     Nivel = Niveles.Municipal
                 },
                 new NivelSeguimiento
                 {
                     Nivel = Niveles.Local
                 }
             );
            #endregion


            context.SaveChanges();

        }
        #endregion
    }
}