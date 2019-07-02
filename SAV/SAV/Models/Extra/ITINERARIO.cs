using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(ItinerarioMetadata))]
    public partial class ITINERARIO
    {
        public string ItinerarioCompleto
        {
            get
            {
                return String.Format("origen: {0}\t Hora salida: {1}\t Destino: {2}\t Hora llegada {3}", ORIGEN, HORA_SALIDA, DESTINO, HORA_LLEGADA);
            }
        }
    }
    public class ItinerarioMetadata
    {

        public int ID_ITINERARIO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleccionar origen requerrido")]
        [Display(Name = "Origen: ")]
        public string ORIGEN { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleccionar Destino requerrido")]
        [Display(Name = "Destino: ")]
        public string DESTINO { get; set; }
        [DataType(DataType.Time)]
    
        [Display(Name = "Hora salida ")]
        public TimeSpan HORA_SALIDA { get; set; }
        [DataType(DataType.Time)]
     
        [Display(Name = "Hora llegada ")]
        public TimeSpan HORA_LLEGADA { get; set; }

        public string ItinerarioCompleto
        {
            get
            {
                return String.Format("origen: {0}\t Hora salida: {1}\t Destino: {2}\t Hora llegada {3}", ORIGEN, HORA_SALIDA, DESTINO,HORA_LLEGADA);
            }
        }


    }
}