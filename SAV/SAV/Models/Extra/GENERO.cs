using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(GeneroMetadata))]
    public partial class GENERO
    {
    }
    public class GeneroMetadata
    {

        public int ID_GENERO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "nombre del genero  requerrido")]
        [Display(Name = "Genero: ")]
        public string NOM_GENERO { get; set; }
    }

}