using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(RegionMetadata))]
    public partial class REGION
    {

    }
    public class RegionMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Codigo del pais requerrido")]
        [Display(Name = "Codgio pais: ")]
        public string COD_PAIS { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Codigo de la region requerrido")]
        [Display(Name = "Codgio region: ")]
        public string COD_REGION { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre de la region requerrido")]
        [Display(Name = "Nombre region: ")]
        public string NOM_REGION { get; set; }
       
    }
}