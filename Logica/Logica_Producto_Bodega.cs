using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Producto_Bodega
    {
        Datos_Producto_Bodega op = new Datos_Producto_Bodega();

        public List<PRODUCTO_BODEGA> SeleccionarProductoBodega()
        {
            return op.SeleccionarProductoBodega();
        }

        public List<PRODUCTO_BODEGA> SeleccionarProductoBodegaPorCodigo(string prodCodigo)
        {
            return SeleccionarProductoBodega().Where(pb => pb.PROD_CODIGO == prodCodigo).ToList();
        }

        public string InsertarProductoBodega(string prodCodigo, string bodegaCodigo, int cantidad)
        {
            PRODUCTO_BODEGA nuevoProductoBodega = new PRODUCTO_BODEGA
            {
                PROD_CODIGO = prodCodigo,
                BOD_COD = bodegaCodigo,
                PRBO_CANTIDAD = cantidad
            };
            return op.insertarProductoBodega(nuevoProductoBodega);
        }

        public string ModificarProductoBodega(string prodCodigo, string bodegaCodigo, int nuevaCantidad)
        {
            PRODUCTO_BODEGA productoBodegaModificado = new PRODUCTO_BODEGA
            {
                PROD_CODIGO = prodCodigo,
                BOD_COD = bodegaCodigo,
                PRBO_CANTIDAD = nuevaCantidad
            };
            return op.modificarProductoBodega(productoBodegaModificado);
        }

        public string EliminarProductoBodega(string prodCodigo, string bodegaCodigo)
        {
            return op.eliminarProductoBodega(prodCodigo, bodegaCodigo);
        }
    }
}
