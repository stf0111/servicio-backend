using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Producto_Proveedor
    {
        Datos_Producto_Proveedor op = new Datos_Producto_Proveedor();

        public List<PRODUCTO_PROVEEDOR> SeleccionarProductoProveedor()
        {
            return op.SeleccionarProductoProveedor();
        }

        // Selecciona todos los registros que coincidan con el código del producto.
        public List<PRODUCTO_PROVEEDOR> SeleccionarProductoProveedorPorCodigoProducto(string prodCodigo)
        {
            return op.SeleccionarProductoProveedor().Where(pp => pp.PROD_CODIGO == prodCodigo).ToList();
        }

        // Selecciona todos los registros que coincidan con el código del proveedor.
        public List<PRODUCTO_PROVEEDOR> SeleccionarProductoProveedorPorCodigoProveedor(string provCodigo)
        {
            return op.SeleccionarProductoProveedor().Where(pp => pp.PROV_COD == provCodigo).ToList();
        }

        public string InsertarProductoProveedor(string prodCodigo, string provCodigo, string observaciones)
        {
            PRODUCTO_PROVEEDOR nuevoProductoProveedor = new PRODUCTO_PROVEEDOR
            {
                PROD_CODIGO = prodCodigo,
                PROV_COD = provCodigo,
                OBSERVACIONES = observaciones
            };
            return op.insertarProductoProveedor(nuevoProductoProveedor);
        }

        public string ModificarProductoProveedor(string prodCodigo, string provCodigo, string observaciones)
        {
            PRODUCTO_PROVEEDOR productoProveedorModificado = new PRODUCTO_PROVEEDOR
            {
                PROD_CODIGO = prodCodigo,
                PROV_COD = provCodigo,
                OBSERVACIONES = observaciones
            };
            return op.modificarProductoProveedor(productoProveedorModificado);
        }

        public string EliminarProductoProveedor(string prodCodigo, string provCodigo)
        {
            return op.eliminarProductoProveedor(prodCodigo, provCodigo);
        }
    }
}
