using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    public class ResetContraModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "nueva Contraseña requerida")]
        [Display(Name = "Contaseña ")]
        [DataType(DataType.Password)]
        public string NuevaContra { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirmacion de Contraseña requerida")]
        [Display(Name = "Confirmar Contraseña ")]
        [DataType(DataType.Password)]
        [Compare("NuevaContra", ErrorMessage = "Las contraseñas son diferentes")]
        public string ConfirmarContra { get; set; }
        [Required]
        public string ResetCode { get; set; }
    }
}