using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SAV.Models
{
    [MetadataType(typeof(ClienteNaturalMetadata))]
    public partial class CLIENTE_NATURAL
    {
        string userName = HttpContext.Current.User.Identity.Name;
        int i = (int)Membership.GetUser().ProviderUserKey;
    }
    public class ClienteNaturalMetadata
    {

        public int ID_NATURAL { get; set; }
        public int ID_Persona { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleccionar tipo documento requerrido")]
        [Display(Name = "Tipo de documento: ")]
        public int ID_TIPO_DOCUMENTO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Numero de documento requerrido")]
        [Display(Name = "Numero de documento: ")]
        public string NUM_DOCUMETO { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FECHA_NACIMIENTO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleccionar genero  requerrido")]
        [Display(Name = "Genero: ")]

        public int ID_GENERO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Estado civil  requerrido")]
        [Display(Name = "Estado civil: ")]

        public string ESTADO_CIVIL { get; set; }

        [Display(Name = "Numero de millas: ")]
        public int NUM_MILLAS { get; set; }

        [Display(Name = "Numero de viajero frecuente: ")]
        public string NUM_VIAJERO_FREC { get; set; }
    }
}