using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.PRODUCTO_BODEGA = new List<PRODUCTO_BODEGA>();
            this.PRODUCTO_FACTURA = new List<PRODUCTO_FACTURA>();
            this.PRODUCTO_PROVEEDOR = new List<PRODUCTO_PROVEEDOR>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<PRODUCTO_BODEGA> PRODUCTO_BODEGA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<PRODUCTO_FACTURA> PRODUCTO_FACTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<PRODUCTO_PROVEEDOR> PRODUCTO_PROVEEDOR { get; set; }

    }
}
