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
    
    public partial class RESERVACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESERVACION()
        {
            this.REGISTRO_PAGO = new HashSet<REGISTRO_PAGO>();
        }
    
        public int COD_RESERVACION { get; set; }
        public Nullable<int> ID_PAGO { get; set; }
        public int ID_CLIENTE { get; set; }
        public byte[] FECHA_RESERVACION { get; set; }
        public Nullable<System.DateTime> FECHA_SALIDA { get; set; }
        public Nullable<System.DateTime> FECHA_REGRESO { get; set; }
        public string ESTADO_PAGO { get; set; }
        public Nullable<int> TOTAL_MALETAS { get; set; }
        public Nullable<int> COD_VUELO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTRO_PAGO> REGISTRO_PAGO { get; set; }
        public virtual VUELO VUELO { get; set; }
    }
}
