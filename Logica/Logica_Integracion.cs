using Acceso_Datos.DTO;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Integracion
    {
        Datos_Integracion datosIntegracion = new Datos_Integracion();

        // Método para seleccionar facturas pendientes y calcular el total
        public List<IntegracionSuple> Facturas(string clienteID)
        {
            return datosIntegracion.Facturas(clienteID);
        }

        // Método para verificar el stock por factura utilizando PRODUCTO_FACTURA y PRODUCTO_BODEGA
        public bool VerificarStockPorFactura(string codigoFactura)
        {
            return datosIntegracion.VerificarStockPorFactura(codigoFactura);
        }

        // Método para actualizar la factura y el stock de productos en la bodega
        public bool ActualizarFacturaYStock(string codigoFactura)
        {
            try
            {
                datosIntegracion.ActualizarFacturaYStock(codigoFactura);
                return true; // Retorna true si la llamada al método se completó sin errores
            }
            catch (Exception)
            {
                return false; // Retorna false si hubo una excepción durante la llamada
            }
        }

    }



}
