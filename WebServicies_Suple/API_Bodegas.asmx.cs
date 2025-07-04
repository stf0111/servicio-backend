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
    /// Descripción breve de API_Bodegas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Bodegas : System.Web.Services.WebService
    {


        Logica_Bodegas logicaBodegas = new Logica_Bodegas();

        [WebMethod]
        public List<BODEGA> SeleccionarBodegas()
        {
            return logicaBodegas.SeleccionarBodegas();
        }

        [WebMethod]
        public BODEGA SeleccionarBodegaPorCodigo(string codigoBOD)
        {
            return logicaBodegas.SeleccionarBodegaPorCodigo(codigoBOD);
        }

        [WebMethod]
        public string InsertarBodega(string bodCodigo, string bodNombre)
        {
            BODEGA nuevaBodega = new BODEGA
            {
                BOD_COD = bodCodigo,
                BOD_NOMBRE = bodNombre
            };
            return logicaBodegas.InsertarBodega(nuevaBodega);
        }

        [WebMethod]
        public string ModificarBodega(string bodCodigo, string bodNombre)
        {
            BODEGA bodegaModificada = new BODEGA
            {
                BOD_COD = bodCodigo,
                BOD_NOMBRE = bodNombre
            };
            return logicaBodegas.ModificarBodega(bodegaModificada);
        }

        [WebMethod]
        public string EliminarBodega(string codigoBOD)
        {
            return logicaBodegas.EliminarBodega(codigoBOD);
        }
    }
}
