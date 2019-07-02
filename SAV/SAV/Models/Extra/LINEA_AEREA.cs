using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(LineaAereaMetadata))]
    public partial class LINEA_AEREA
    {
    }
    public class LineaAereaMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "codigo Linea aerea  requerido")]
        [Display(Name = "Codgio de linea aerea  ")]
        public string COD_LINEA_AEREA { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre del aeropuerto  requerido")]
        [Display(Name = "Nombre de aeropuerto")]
        public string COD_AEROPUERTO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre oficial  requerido")]
        [Display(Name = "Nombre oficial de la linea aerea")]
        public string NOM_OFICIAL { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre corto  requerido")]
        [Display(Name = "Nombre corto de la linea aerea")]
        public string NOM_CORTO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre del representante  requerido")]
        [Display(Name = "Nombre del representante")]
        public string NOM_REPRESENTANTE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pais  requerido")]
        [Display(Name = "Pais de creacion de la linea aerea")]
        public string COD_PAIS { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pagina web requerido")]
        [Display(Name = "Pagina web oficial")]
        public string URL { get; set; }

        [Display(Name = "facebook")]
        public string FACEBOOK { get; set; }

        [Display(Name = "twitter")]
        public string TWITTER { get; set; }

        [Display(Name = "instagram")]
        public string INSTAGRAM { get; set; }

        [Display(Name = "youtube")]
        public string YOUTUBE { get; set; }

        [Display(Name = "Correo electronico")]
        public string EMAIL { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "fecha de fundacion ")]
        public DateTime FECHA_FUNDACION { get; set; }
    }
}