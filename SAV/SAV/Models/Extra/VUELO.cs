using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(VueloMetadata))]
    public partial class VUELO
    {

    }
    public class VueloMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "codigo vuelo requerido")]
        [Display(Name = "Codgio de vuelo  ")]
        public string COD_VUELO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Linea aerea requerido")]
        [Display(Name = "Linea aerea  ")]
        public string COD_LINEA_AEREA { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Millas recorridas requerido")]
        [Display(Name = "Millas recorrida avion  ")]
        public double MILLAS_REALES { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Millas recorrida requerido")]
        [Display(Name = "Millas otorgara al pasajero  ")]
        public int MILLAS_OTROGADAS { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "placa del avion requerido")]
        [Display(Name = "Placa del avion  ")]
        public string PLACA_AVION { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "itinerario requerido")]
        [Display(Name = "Itinerario  ")]
        public int ID_ITINERARIO { get; set; }
        [Display(Name = "Fecha de salida  ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "fecha de salida requerido")]
        public DateTime FECHA_SALIDA { get; set; }
        [Display(Name = "Disponibilidad")]
        public int DISPONIBILIDAD { get; set; }




    }
}