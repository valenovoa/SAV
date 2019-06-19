using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    public  class Usuario
    {
        public int ID_USUARIO { get; set; }
        public string COD_ROL { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Correo electronico requerrido")]
        [Display(Name = "Correo Electronico: ")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contraseña requerida")]
        [Display(Name = "Contaseña ")]
        [DataType(DataType.Password)]
        public string CONTASENA { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirmacion de Contraseña requerida")]
        [Display(Name = "Confirmar Contraseña ")]
        [DataType(DataType.Password)]
        [Compare("CONTASENA", ErrorMessage = "Las contraseñas son diferentes")]
        public string CONFIRMAR_CONTRASENA { get; set; }
        public Nullable<bool> ESTADO { get; set; }
        // public virtual Persona Persona { get; set; }
    

  

   
        // persona

        public int ID_Persona { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Primer nombre requerrido")]
        [Display(Name = "Primer Nombre: ")]
        public string PRIMER_NOM { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Segundo nombre requerrido")]
        [Display(Name = "Segundo Nombre: ")]
        public string SEGUNDO_NOM { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Primer apeliido requerrido")]
        [Display(Name = "Primer apellido: ")]
        public string PRIMER_APELLIDO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Segundo apeliido requerrido")]
        [Display(Name = "Segundo apellido: ")]
        public string SEGUNDO_APELLIDO { get; set; }

        [Display(Name = "Telefono fijo: ")]
        public string TEL_FIJO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Telefono movil requerrido")]
        [Display(Name = "Telefono movi: ")]
        public string TEL_MOVIL { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Direccion requerrido")]
        [Display(Name = "Direccion: ")]
        public string DIRECCION { get; set; }
    }
}