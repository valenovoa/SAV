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
    
    public partial class REGISTRO_PAGO
    {
        public int ID_PAGO { get; set; }
        public int COD_RESERVACION { get; set; }
        public string COD_CIUDAD { get; set; }
        public Nullable<double> TOTAL_PAGO { get; set; }
        public Nullable<double> PAGO_MALETA_EXTRA { get; set; }
        public Nullable<int> ID_MALETA { get; set; }
        public string COD_CLASE { get; set; }
    
        public virtual MALETA_EXTRA MALETA_EXTRA { get; set; }
        public virtual RESERVACION RESERVACION { get; set; }
        public virtual TIPO_CLASE TIPO_CLASE { get; set; }
    }
}