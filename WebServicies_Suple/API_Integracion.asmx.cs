using Acceso_Datos.DTO;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServicies_Suple
{
    /// <summary>
    /// Descripción breve de API_Integracion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Integracion : System.Web.Services.WebService
    {
        Logica_Integracion logicaIntegracion = new Logica_Integracion();

        [WebMethod]
        public List<IntegracionSuple> Facturas(string clienteID)
        {
            return logicaIntegracion.Facturas(clienteID);
        }

        [WebMethod]
        public bool VerificarStockPorFactura(string codigoFactura)
        {
            return logicaIntegracion.VerificarStockPorFactura(codigoFactura);
        }

        [WebMethod]
        public bool ActualizarFacturaYStock(string codigoFactura)
        {
            try
            {
                logicaIntegracion.ActualizarFacturaYStock(codigoFactura);
                return true; // Retorna true si el método se ejecuta sin errores
            }
            catch (Exception)
            {
                return false; // Retorna false si ocurre alguna excepción durante la ejecución
            }
        }

    }
}
