//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAV.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CIUDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIUDAD()
        {
            this.AEROPUERTO = new HashSet<AEROPUERTO>();
        }
    
        public string COD_CIUDAD { get; set; }
        public Nullable<int> ID_PAGO { get; set; }
        public string NOM_CIUDAD { get; set; }
        public string COD_PAIS { get; set; }
        public Nullable<double> TAXES { get; set; }
        public string COD_SUBREGION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AEROPUERTO> AEROPUERTO { get; set; }
        public virtual SUBREGION SUBREGION { get; set; }
    }
}