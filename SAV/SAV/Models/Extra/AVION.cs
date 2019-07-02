using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models

{
    [MetadataType(typeof(AvionMetadata))]
    public partial class AVION
    {
    }
    public class AvionMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Placa del avion requerrido")]
        [Display(Name = "Placa del avion: ")]
        public string PLACA_AVION { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tipo de avion requerrido")]
        [Display(Name = "Tipo de avion: ")]
        public int ID_TIPO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Marca de avion requerrido")]
        [Display(Name = "Marca de avion: ")]
        public string COD_MARCA { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Capacidad de asientos del avion requerrido")]
        [Display(Name = "Capacidad de asientos: ")]
        public int CAPACIDAD_ASIENTO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Linea aerea requerrido")]
        [Display(Name = "Linea aerea: ")]
        public string COD_LA { get; set; }

        [Display(Name = "Estado del avion: ")]
        public bool ESTADO_AVION { get; set; }
    }


}