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
    /// Descripción breve de API_Producto_Bodega
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Producto_Bodega : System.Web.Services.WebService
    {

        Logica_Producto_Bodega logicaProductoBodega = new Logica_Producto_Bodega();

        [WebMethod]
        public List<PRODUCTO_BODEGA> SeleccionarProductoBodega()
        {
            return logicaProductoBodega.SeleccionarProductoBodega();
        }

        [WebMethod]
        public List<PRODUCTO_BODEGA> SeleccionarProductoBodegaPorCodigo(string prodCodigo)
        {
            return SeleccionarProductoBodega().Where(pb => pb.PROD_CODIGO == prodCodigo).ToList();
        }

        [WebMethod]
        public string InsertarProductoBodega(string prodCodigo, string bodegaCodigo, int cantidad)
        {
            return logicaProductoBodega.InsertarProductoBodega(prodCodigo, bodegaCodigo, cantidad);
        }

        [WebMethod]
        public string ModificarProductoBodega(string prodCodigo, string bodegaCodigo, int nuevaCantidad)
        {
            return logicaProductoBodega.ModificarProductoBodega(prodCodigo, bodegaCodigo, nuevaCantidad);
        }

        [WebMethod]
        public string EliminarProductoBodega(string prodCodigo, string bodegaCodigo)
        {
            return logicaProductoBodega.EliminarProductoBodega(prodCodigo, bodegaCodigo);
        }
    }
}
