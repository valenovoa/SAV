//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAV.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class GETAWEY
    {
        public int ID_GETEWAY { get; set; }
        public string COD_AEROPUERTO { get; set; }
        public string PLACA_AVION { get; set; }
        public Nullable<System.DateTime> FECHA_ABORDAJE { get; set; }
        public Nullable<System.TimeSpan> HORA_ABORDAJE { get; set; }
        public Nullable<System.TimeSpan> HORA_DESABORDAJE { get; set; }
        public Nullable<System.DateTime> FECHA_DESABORDAJE { get; set; }
        public Nullable<bool> ESTADO_GETAWEY { get; set; }
    
        public virtual AEROPUERTO AEROPUERTO { get; set; }
        public virtual AVION AVION { get; set; }
    }
}
