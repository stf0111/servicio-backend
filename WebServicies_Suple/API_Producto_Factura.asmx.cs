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
    /// Descripción breve de API_Producto_Factura
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Producto_Factura : System.Web.Services.WebService
    {

        Logica_Producto_Factura logicaProductoFactura = new Logica_Producto_Factura();

        [WebMethod]
        public List<PRODUCTO_FACTURA> SeleccionarProductoFactura()
        {
            return logicaProductoFactura.SeleccionarProductoFactura();
        }

        [WebMethod]
        public List<PRODUCTO_FACTURA> SeleccionarProductoFacturaPorCodigo(string facCodigo)
        {
            return logicaProductoFactura.SeleccionarProductoFacturaPorCodigo(facCodigo);
        }

        [WebMethod]
        public string InsertarProductoFactura(string prodCodigo, string facCodigo, int cantidad, decimal precio)
        {
            return logicaProductoFactura.InsertarProductoFactura(prodCodigo, facCodigo, cantidad, precio);
        }

        [WebMethod]
        public string ModificarProductoFactura(string prodCodigo, string facCodigo, int nuevaCantidad, decimal nuevoPrecio)
        {
            return logicaProductoFactura.ModificarProductoFactura(prodCodigo, facCodigo, nuevaCantidad, nuevoPrecio);
        }

        [WebMethod]
        public string EliminarProductoFactura(string prodCodigo, string facCodigo)
        {
            return logicaProductoFactura.EliminarProductoFactura(prodCodigo, facCodigo);
        }
    }
}
