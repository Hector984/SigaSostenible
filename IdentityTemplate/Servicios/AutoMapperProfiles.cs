using AutoMapper;
using IdentityTemplate.Models.VariablesDeSeguimiento;
using IdentityTemplate.ViewModels.VariablesSeguimiento;

namespace IdentityTemplate.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<VariableSeguimientoViewModel, VariableSeguimiento>();
        }
    }
}
