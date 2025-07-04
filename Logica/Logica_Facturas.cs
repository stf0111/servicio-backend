using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Facturas
    {
        Datos_Facturas op = new Datos_Facturas();

        public List<FACTURA> SeleccionarFactura()
        {
            return op.SeleccionarFactura();

        }

        public FACTURA SeleccionarFacturaPorCod(string codigoFACp)
        {
            return SeleccionarFactura().Where(cat => cat.FAC_COD == codigoFACp).SingleOrDefault();
        }

        public FACTURA SeleccionarFacturaPorCed(string cedulaFACp)
        {
            return SeleccionarFactura().Where(cat => cat.CLI_CEDULA == cedulaFACp).SingleOrDefault();
        }


        public string insertarFactura(FACTURA nuevaFACp)
        {
            return op.insertarFactura(nuevaFACp);
        }


        public string modificarFactura(FACTURA facturaModificadop)
        {
            // Delega la modificación a la capa de datos
            return op.modificarFactura(facturaModificadop);
        }

        public string eliminarFactura(string codigoFacturap)
        {
            // Delega la eliminación a la capa de datos
            return op.eliminarFactura(codigoFacturap);
        }
    }
}
