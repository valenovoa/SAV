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
    
    public partial class ORIGENDESTINO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORIGENDESTINO()
        {
            this.ITINERARIO = new HashSet<ITINERARIO>();
        }
    
        public int id_O_D { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public Nullable<bool> escala { get; set; }
        public Nullable<int> id_escala { get; set; }
    
        public virtual CIUDAD CIUDAD { get; set; }
        public virtual CIUDAD CIUDAD1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITINERARIO> ITINERARIO { get; set; }
    }
}
