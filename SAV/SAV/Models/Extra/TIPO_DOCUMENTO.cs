using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(TipoDocumentoMetadata))]
    public partial class TIPO_DOCUMENTO
    {
    }
    public class TipoDocumentoMetadata
    {
        public int ID_TIPO_DOCUMENTO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre del tipo de documento  requerrido")]
        [Display(Name = "Nombre del documento: ")]
        public string NOM_DOCUMENTO { get; set; }

    }
}