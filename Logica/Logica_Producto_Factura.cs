using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Producto_Factura
    {
        Datos_Producto_Factura op = new Datos_Producto_Factura();

        public List<PRODUCTO_FACTURA> SeleccionarProductoFactura()
        {
            return op.SeleccionarProductoFactura();
        }

        public List<PRODUCTO_FACTURA> SeleccionarProductoFacturaPorCodigo(string facCodigo)
        {
            return SeleccionarProductoFactura().Where(pf => pf.FAC_COD == facCodigo).ToList();
        }


        public string InsertarProductoFactura(string prodCodigo, string facCodigo, int cantidad, decimal precio)
        {
            PRODUCTO_FACTURA nuevoProductoFactura = new PRODUCTO_FACTURA
            {
                PROD_CODIGO = prodCodigo,
                FAC_COD = facCodigo,
                FP_CANTIDAD = cantidad,
                FP_PRECIO = precio
            };
            return op.insertarProductoFactura(nuevoProductoFactura);
        }

        public string ModificarProductoFactura(string prodCodigo, string facCodigo, int nuevaCantidad, decimal nuevoPrecio)
        {
            PRODUCTO_FACTURA productoFacturaModificado = new PRODUCTO_FACTURA
            {
                PROD_CODIGO = prodCodigo,
                FAC_COD = facCodigo,
                FP_CANTIDAD = nuevaCantidad,
                FP_PRECIO = nuevoPrecio
            };
            return op.modificarProductoFactura(productoFacturaModificado);
        }

        public string EliminarProductoFactura(string prodCodigo, string facCodigo)
        {
            return op.eliminarProductoFactura(prodCodigo, facCodigo);
        }
    }
}
