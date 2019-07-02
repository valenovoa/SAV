using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(GetaweyMetadata))]
    public partial class GETAWEY
    {
    }

    public class GetaweyMetadata
    {
        public int ID_GETEWAY { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre del aeropuerto  requerido")]
        [Display(Name = "Nombre del aeropuerto  ")]
        public string COD_AEROPUERTO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Placa del avion requerido")]
        [Display(Name = "Placa del avion ")]
        public string PLACA_AVION { get; set; }
        [Display(Name = "Fecha de abordaje ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FECHA_ABORDAJE { get; set; }
        
        [DataType(DataType.Time)]

        [Display(Name = "Hora de abordaje ")]
        public TimeSpan HORA_ABORDAJE { get; set; }
        [DataType(DataType.Time)]
     
        [Display(Name = "Hora de desabordaje  ")]
        public TimeSpan HORA_DESABORDAJE { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "fecha de desabordaje ")]
        public DateTime FECHA_DESABORDAJE { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre de la linea aerea  requerido")]
        [Display(Name = "Nombre de la linea aerea ")]
        public string COD_LINEA_AEREA { get; set; }

        [Display(Name = "Estado del getawey ")]
        public bool ESTADO_GETAWEY { get; set; }
    }
}