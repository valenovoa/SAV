using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(PaisMetadata))]
    public partial class PAIS
    {
    }
    public class PaisMetadata {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Codigo del pais requerrido")]
        [Display(Name = "Codigo pais: ")]
        public string COD_PAIS { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre del pais requerrido")]
        [Display(Name = "Nombre del pais: ")]
        public string NOM_PAIS { get; set; }
    }
   
}