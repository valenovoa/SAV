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
    
    public partial class ASIENTO
    {
        public int ID_ASIENTO { get; set; }
        public string COD_CLASE { get; set; }
        public string PLACA_AVION { get; set; }
        public Nullable<int> ID_TICKET { get; set; }
        public Nullable<int> NUMERO { get; set; }
    }
}