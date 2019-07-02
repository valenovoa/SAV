using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(SubregionMetadata))]
    public partial class SUBREGION
    {
    }
    public class SubregionMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Codigo de region requerrido")]
        [Display(Name = "Codigo region: ")]
        public string COD_REGION { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Codigo subregion requerrido")]
        [Display(Name = "Codigo subregion: ")]
        public string COD_SUBREGION { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre de la subregion requerrido")]
        [Display(Name = "nombre de subregion: ")]
        public string NOM_SUBREGION { get; set; }
        
    }
}