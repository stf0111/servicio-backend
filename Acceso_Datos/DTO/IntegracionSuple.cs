using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos.DTO
{
    public class IntegracionSuple
    {
        public string Id_Cliente { get; set; }
        public int Id_Servicio { get; set; }
        public decimal Monto { get; set; }
        public string Id_Factura { get; set; }

    }
}
