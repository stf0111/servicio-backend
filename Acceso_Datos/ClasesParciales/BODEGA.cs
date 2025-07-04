using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public partial class BODEGA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BODEGA()
        {
            this.PRODUCTO_BODEGA = new List<PRODUCTO_BODEGA>();
            this.PRODUCTO_BODEGA1 = new List<PRODUCTO_BODEGA>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<PRODUCTO_BODEGA> PRODUCTO_BODEGA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<PRODUCTO_BODEGA> PRODUCTO_BODEGA1 { get; set; }
    }
}
