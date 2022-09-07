using IdentityTemplate.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdentityTemplate.Helpers
{

    public interface ICatalogosHelpers
    {
        Task<IEnumerable<SelectListItem>> ObtenerNivelesDeresponsabilidad();
        Task<IEnumerable<SelectListItem>> ObtenerNivelesDeSeguimiento();
        Task<IEnumerable<SelectListItem>> ObtenerPoliticas();
        Task<IEnumerable<SelectListItem>> ObtenerTipoInstituciones();
    }

    public class CatalogosHelpers : ICatalogosHelpers
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public CatalogosHelpers(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
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
    }
}
