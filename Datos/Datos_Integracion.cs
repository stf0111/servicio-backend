using Acceso_Datos.DTO;
using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Datos_Integracion
    {
        // api/Integracion/Facturas/{clienteID}: (Recibe como parametro la cedula)
        public List<IntegracionSuple> Facturas(string clienteID)
        {
            // Obtener clientes
            Datos_Clientes datosCliente = new Datos_Clientes();
            List<CLIENTE> clientes = datosCliente.SeleccionarCliente();

            // Filtrar el cliente específico por CI
            CLIENTE cliente = clientes.FirstOrDefault(c => c.CLI_CEDULA.Equals(clienteID));

            if (cliente == null)
            {
                return new List<IntegracionSuple>(); // Retornar lista vacía si no se encuentra el cliente
            }

            // Obtener facturas pendientes
            Datos_Facturas datosFactura = new Datos_Facturas();
            List<FACTURA> facturasPendientes = datosFactura
                .SeleccionarFactura()
                .Where(f => f.FAC_ESTADO.Equals("PENDIENTE", StringComparison.OrdinalIgnoreCase) && f.CLI_CEDULA == clienteID)
                .ToList();

            // Obtener detalles de productos en facturas
            Datos_Producto_Factura datosProductoFactura = new Datos_Producto_Factura();
            List<PRODUCTO_FACTURA> productosFactura = datosProductoFactura.SeleccionarProductoFactura();

            List<IntegracionSuple> resultados = new List<IntegracionSuple>();

            foreach (var factura in facturasPendientes)
            {
                decimal montoTotal = (decimal)productosFactura
                    .Where(pf => pf.FAC_COD == factura.FAC_COD)
                    .Sum(pf => pf.FP_CANTIDAD * pf.FP_PRECIO);

                IntegracionSuple integracion = new IntegracionSuple
                {
                    Id_Cliente = factura.CLI_CEDULA,
                    Id_Servicio = 4,  // Assuming a constant service ID for all
                    Monto = montoTotal,
                    Id_Factura = factura.FAC_COD
                };

                resultados.Add(integracion);
            }

            return resultados;
        }


        public bool VerificarStockPorFactura(string codigoFactura)
        {
            Datos_Producto_Factura datosProductoFactura = new Datos_Producto_Factura();
            List<PRODUCTO_FACTURA> detallesFactura = datosProductoFactura.SeleccionarProductoFactura()
                .Where(pf => pf.FAC_COD == codigoFactura).ToList();

            Datos_Producto_Bodega datosProductoBodega = new Datos_Producto_Bodega();
            List<PRODUCTO_BODEGA> productosBodega = datosProductoBodega.SeleccionarProductoBodega();

            foreach (var detalle in detallesFactura)
            {
                var productoBodega = productosBodega.FirstOrDefault(pb => pb.PROD_CODIGO == detalle.PROD_CODIGO);
                if (productoBodega == null || productoBodega.PRBO_CANTIDAD < detalle.FP_CANTIDAD)
                {
                    return false; // Not enough stock
                }
            }

            return true; // Sufficient stock
        }

        public bool ActualizarFacturaYStock(string codigoFactura)
        {
            try
            {
                Datos_Producto_Factura datosProductoFactura = new Datos_Producto_Factura();
                List<PRODUCTO_FACTURA> detallesFactura = datosProductoFactura.SeleccionarProductoFactura()
                    .Where(pf => pf.FAC_COD == codigoFactura).ToList();

                Datos_Producto_Bodega datosProductoBodega = new Datos_Producto_Bodega();
                List<PRODUCTO_BODEGA> productosBodega = datosProductoBodega.SeleccionarProductoBodega();

                foreach (var detalle in detallesFactura)
                {
                    var productoBodega = productosBodega.FirstOrDefault(pb => pb.PROD_CODIGO == detalle.PROD_CODIGO);
                    if (productoBodega != null)
                    {
                        productoBodega.PRBO_CANTIDAD -= detalle.FP_CANTIDAD; // Update stock
                        datosProductoBodega.modificarProductoBodega(productoBodega); // Save changes
                    }
                }

                Datos_Facturas datosFactura = new Datos_Facturas();
                FACTURA factura = datosFactura.SeleccionarFactura()
                    .FirstOrDefault(f => f.FAC_COD == codigoFactura);

                if (factura != null)
                {
                    factura.FAC_ESTADO = "PAGADO"; // Update invoice status
                    datosFactura.modificarFactura(factura); // Save changes
                }

                return true; // Return true if all operations completed successfully
            }
            catch (Exception)
            {
                return false; // Return false if an exception occurs
            }
        }
    }

}