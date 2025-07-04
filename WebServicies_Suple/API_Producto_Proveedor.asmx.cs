using Acceso_Datos;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServicies_Suple
{
    /// <summary>
    /// Descripción breve de API_Producto_Proveedor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Producto_Proveedor : System.Web.Services.WebService
    {

        Logica_Producto_Proveedor logicaProductoProveedor = new Logica_Producto_Proveedor();

        [WebMethod]
        public List<PRODUCTO_PROVEEDOR> SeleccionarTodosLosProductosProveedores()
        {
            return logicaProductoProveedor.SeleccionarProductoProveedor();
        }

        [WebMethod]
        // Selecciona todos los registros que coincidan con el código del producto.
        public List<PRODUCTO_PROVEEDOR> SeleccionarProductoProveedorPorCodigoProducto(string prodCodigo)
        {
            return logicaProductoProveedor.SeleccionarProductoProveedor().Where(pp => pp.PROD_CODIGO == prodCodigo).ToList();
        }

        [WebMethod]

        // Selecciona todos los registros que coincidan con el código del proveedor.
        public List<PRODUCTO_PROVEEDOR> SeleccionarProductoProveedorPorCodigoProveedor(string provCodigo)
        {
            return logicaProductoProveedor.SeleccionarProductoProveedor().Where(pp => pp.PROV_COD == provCodigo).ToList();
        }

        [WebMethod]
        public string InsertarProductoProveedor(string prodCodigo, string provCodigo, string observaciones)
        {
            return logicaProductoProveedor.InsertarProductoProveedor(prodCodigo, provCodigo, observaciones);
        }

        [WebMethod]
        public string ModificarProductoProveedor(string prodCodigo, string provCodigo, string observaciones)
        {
            return logicaProductoProveedor.ModificarProductoProveedor(prodCodigo, provCodigo, observaciones);
        }

        [WebMethod]
        public string EliminarProductoProveedor(string prodCodigo, string provCodigo)
        {
            return logicaProductoProveedor.EliminarProductoProveedor(prodCodigo, provCodigo);
        }
    }
}
