using System;
using System.ComponentModel.DataAnnotations;

namespace UI.Models.PersonaFisica
{
    //Hay librerias bien padres que se pueden usar para validar los campos y no adornarlos con el DataAnnotations
    public class PersonaFisica
    {
        public int IdPersonaFisica { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Registro")]
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Display(Name = "RFC")]
        [MinLength(13, ErrorMessage = "El campo RFC debe tener minimo 13 caracteres")]
        [MaxLength(13, ErrorMessage = "El campo RFC debe tener maximo 13 caracteres")]
        public string RFC { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<int> UsuarioAgrega { get; set; }

        [Display(Name = "Estatus")]
        public Nullable<bool> Activo { get; set; }
    }
}