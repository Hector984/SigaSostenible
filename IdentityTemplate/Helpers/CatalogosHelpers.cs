using IdentityTemplate.Areas.Identity.Data;
using IdentityTemplate.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static IdentityTemplate.Models.Catalogos.Rol;

namespace IdentityTemplate.Helpers
{

    public interface ICatalogosHelpers
    {
        Task<IEnumerable<SelectListItem>> ObtenerNivelesDeresponsabilidad();
        Task<IEnumerable<SelectListItem>> ObtenerNivelesDeSeguimiento();
        Task<IEnumerable<SelectListItem>> ObtenerPoliticas();
        Task<IEnumerable<SelectListItem>> ObtenerRol(ApplicationUser usuario);
        Task<IEnumerable<SelectListItem>> ObtenerTipoInstituciones();
    }

    public class CatalogosHelpers : ICatalogosHelpers
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CatalogosHelpers(ApplicationDBContext applicationDBContext, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _applicationDBContext = applicationDBContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerTipoInstituciones()
        {
            var instituciones = await _applicationDBContext.TipoInstituciones.ToListAsync();

            return instituciones.Select(x => new SelectListItem(x.NombreDeInstitucion, x.TipoInstitucionId.ToString()));
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerNivelesDeSeguimiento()
        {
            var nivelesDeSeguimiento = await _applicationDBContext.NivelesSeguimiento.ToListAsync();

            return nivelesDeSeguimiento.Select(x => new SelectListItem(x.NivelDeSeguimiento, x.NivelSeguimientoId.ToString()));
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerNivelesDeresponsabilidad()
        {
            var nivelesDeResponsabilidad = await _applicationDBContext.NivelResponsabilidad.ToListAsync();

            return nivelesDeResponsabilidad.Select(x => new SelectListItem(x.NivelDeResponsabilidad, x.NivelResponsabilidadId.ToString()));
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerPoliticas()
        {
            var politicas = await _applicationDBContext.PoliticaAcciones.ToListAsync();

            return politicas.Select(x => new SelectListItem(x.NombrePolitica, x.PoliticaId.ToString()));
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerRol(ApplicationUser usuario)
        {

            var rolesUsuarioActual = await _userManager.GetRolesAsync(usuario);

            var roles = await _roleManager.Roles.ToListAsync();

            //Si es Administrador solamente registra Validadores
            if (rolesUsuarioActual.Contains(Roles.AdministradorNacional.ToString()))
            {
                
                return roles.Select(x => new SelectListItem(x.NormalizedName, x.Id.ToString()));

            }//Si es Validador solamente registra Ejecutores
            else
            {
                var ejecutor = roles.Find(x => x.Name == Roles.Ejecutor.ToString());

                return roles.Select(x => new SelectListItem(x.NormalizedName, x.Id.ToString())).Where(x => x.Value == ejecutor.Id);

            }

        }
    }
}
