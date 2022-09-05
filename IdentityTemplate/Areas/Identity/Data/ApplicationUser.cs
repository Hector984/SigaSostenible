using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using IdentityTemplate.Models.Catalogos;
using Microsoft.AspNetCore.Identity;

namespace IdentityTemplate.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(maximumLength: 30)]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [Display(Name = "Primer Apellido *")]
    [StringLength(maximumLength: 30)]
    public string PrimerApellido { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [Display(Name = "Segundo Apellido *")]
    [StringLength(maximumLength: 30)]
    public string SegundoApellido { get; set; }
    public string CURP { get; set; }

    [Display(Name = "Correo Personal")]
    [EmailAddress]
    public string CorreoPersonal { get; set; }
    public string TelefonoPersonal { get; set; }

    [Column("n_tipo_institucion", Order = 14)]
    public int TipoInstitucionId { get; set; }
    public virtual TipoInstitucion TipoInstitucion { get; set; }
    public string NombreInstitucion { get; set; }
    public string CargoLaboral { get; set; }

    [Column("n_nivel_seguimiento", Order = 17)]
    public int NivelSeguimientoId { get; set; }
    public virtual NivelSeguimiento NivelSeguimiento { get; set; }

    [Column("n_nivel_responsabilidad", Order = 18)]
    public int NivelResponsabilidadId { get; set; }
    public virtual NivelResponsabilidad NivelResponsabilidad { get; set; }
}

