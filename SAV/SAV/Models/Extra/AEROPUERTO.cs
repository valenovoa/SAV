using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(AeropuertoMetadata))]
    public partial class AEROPUERTO
    {
    }
    public class AeropuertoMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "codigo aeropuerto  requerido")]
        [Display(Name = "Codgio")]
        public string COD_AEROPUERTO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "nombre del aeropuerto  requerido")]
        [Display(Name = "Nombre")]
        public string NOM_AEROPUERTO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "telefono aeropuerto  requerido")]
        [Display(Name = "Telefono")]
        public string TELEFONO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ciudad del  aeropuerto  requerido")]
        [Display(Name = "Ubicacion ")]
        public string COD_CIUDAD { get; set; }
    }
}