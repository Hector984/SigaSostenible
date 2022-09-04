using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityTemplate.Models;
using IdentityTemplate.Models.Catalogs;
using Microsoft.AspNetCore.Identity;

namespace IdentityTemplate.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string CURP { get; set; }
    public string CorreoPersonal { get; set; }
    public string TelefonoPersonal { get; set; }
    public IEnumerable<TipoInstitucion> TipoInstitucion { get; set; }
    public string NombreInstitucion { get; set; }
    public string CargoLaboral { get; set; }
    public virtual IEnumerable<Politica> Politica { get; set; }
    public virtual IEnumerable<NivelSeguimiento> NivelSeguimiento { get; set; }
    public virtual IEnumerable<NivelResponsabilidad> NivelResponsabilidad { get; set; }
}

