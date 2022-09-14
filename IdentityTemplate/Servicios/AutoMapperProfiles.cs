using AutoMapper;
using IdentityTemplate.Models.Catalogos;
using IdentityTemplate.Models.VariableSesguimiento;
using IdentityTemplate.ViewModels.VariablesSeguimiento;

namespace IdentityTemplate.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<VariableSeguimientoViewModel, VariableSeguimiento>();
            CreateMap<PoliticaViewModel, Politica>();
            CreateMap<EjeTematicoViewModel, EjeTematico>();
            CreateMap<LineaEstrategicaViewModel, LineaEstrategica>();
            CreateMap<AccionViewModel, Accion>();
        }
    }
}
