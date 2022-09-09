using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using IdentityTemplate.Models.Catalogos;
using IdentityTemplate.Models.Intermedios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{

    [Remote(action: "VerificarExisteNombreUsuario", controller: "Cuenta")]
    [Required(ErrorMessage = "El campo es requerido")]
    [Display(Name = "Nombre de usuario (nickname) *")]
    public override string UserName { get => base.UserName; set => base.UserName = value; }

    [Required(ErrorMessage = "El campo es requerido")]
    [StringLength(maximumLength: 30)]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    [Display(Name = "Primer Apellido *")]
    [StringLength(maximumLength: 30)]
    public string PrimerApellido { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    [Display(Name = "Segundo Apellido *")]
    [StringLength(maximumLength: 30)]
    public string SegundoApellido { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    [Remote(action: "VerificarExisteCURPUsuario", controller: "Cuenta")]
    [StringLength(maximumLength: 18, MinimumLength = 18, ErrorMessage = "El campo no tiene un formato válido. Son 18 caracteres de longitud.")]
    [Display(Name = "CURP *")]
    public string CURP { get; set; }

    [Display(Name = "Correo Personal")]
    [Remote(action: "VerificarExisteCorreoPersonalUsuario", controller: "Cuenta")]
    [EmailAddress(ErrorMessage = "Ingresa un correo con formato válido.")]
    public string CorreoPersonal { get; set; }

    [Display(Name = "Teléfono Celular")]
    public string TelefonoPersonal { get; set; }

    [Column("n_tipo_institucion", Order = 14)]
    [Display(Name = "Tipo de Institución")]
    public int TipoInstitucionId { get; set; }
    public virtual TipoInstitucion TipoInstitucion { get; set; }
    [Display(Name = "Nombre de la Institución")]
    public string NombreInstitucion { get; set; }

    [Display(Name = "Cargo Laboral")]
    public string CargoLaboral { get; set; }

    [Column("n_nivel_seguimiento", Order = 17)]
    [Display(Name = "Nivel de Seguimiento")]
    public int NivelSeguimientoId { get; set; }
    public virtual NivelSeguimiento NivelSeguimiento { get; set; }

    [Column("n_nivel_responsabilidad", Order = 18)]
    [Display(Name = "Nivel de Reponsabilidad")]
    [NotMapped]
    public int NivelResponsabilidadId { get; set; }
    public virtual NivelResponsabilidad NivelResponsabilidad { get; set; }

    public IEnumerable<PoliticaUsuario> PoliticaUsuario { get; set; }
}

