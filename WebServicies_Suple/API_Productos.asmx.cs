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
    /// Descripción breve de API_Productos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Productos : System.Web.Services.WebService
    {

        Logica_Productos logicaProductos = new Logica_Productos();


        [WebMethod]

        public List<PRODUCTO> SeleccionarProducto()
        {
            return logicaProductos.SeleccionarProducto();

        }

        [WebMethod]
        public PRODUCTO SeleccionarProductoPorCod(string codigoPRODp)
        {
            return SeleccionarProducto().Where(cat => cat.PROD_CODIGO == codigoPRODp).SingleOrDefault();
        }

        [WebMethod]
        public List<PRODUCTO> SeleccionarProductoPorMarca(string marcaPRODp)
        {
            return SeleccionarProducto().Where(cat => cat.PROD_MARCA == marcaPRODp).ToList();
        }

        [WebMethod]
        public List<PRODUCTO> SeleccionarProductoPorTipo(string tipoPRODp)
        {
            return SeleccionarProducto().Where(cat => cat.PROD_TIPO == tipoPRODp).ToList();
        }


        [WebMethod]
        #region metodos de accion
        public string insertarProducto(string prodCod, string prodNom, string prodTipo, string prodMarca, DateTime prodCaducidad, decimal prodPrecVen, decimal prodPrecCom, string prodIma)
        {
            PRODUCTO nuevoProducto = new PRODUCTO
            {
                PROD_CODIGO = prodCod,
                PROD_NOMBRE = prodNom,
                PROD_TIPO = prodTipo,
                PROD_MARCA = prodMarca,
                PROD_CADUCIDAD = prodCaducidad,
                PROD_PRECIOVEN = prodPrecVen,
                PROD_PRECIOCOM = prodPrecCom,
                PROD_IMAGEN = prodIma

            };
            return logicaProductos.insertarProducto(nuevoProducto);
        }

        #endregion
        [WebMethod]
        public string modificarProducto(string prodCod, string prodNom, string prodTipo, string prodMarca, DateTime prodCaducidad, decimal prodPrecVen, decimal prodPrecCom, string prodIma)
        {
            PRODUCTO productoModificado = new PRODUCTO
            {
                PROD_CODIGO = prodCod,
                PROD_NOMBRE = prodNom,
                PROD_TIPO = prodTipo,
                PROD_MARCA = prodMarca,
                PROD_CADUCIDAD = prodCaducidad,
                PROD_PRECIOVEN = prodPrecVen,
                PROD_PRECIOCOM = prodPrecCom,
                PROD_IMAGEN = prodIma
            };
            return logicaProductos.modificarProducto(productoModificado);
        }


        [WebMethod]
        public string eliminarProducto(string codigoProductop)
        {
            return logicaProductos.eliminarProducto(codigoProductop);
        }

    }
}
