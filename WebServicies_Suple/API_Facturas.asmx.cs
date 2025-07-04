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
    /// Descripción breve de API_Facturas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Facturas : System.Web.Services.WebService
    {


        Logica_Facturas logicaFacturas = new Logica_Facturas();


        [WebMethod]

        public List<FACTURA> SeleccionarFactura()
        {
            return logicaFacturas.SeleccionarFactura();

        }

        [WebMethod]
        public FACTURA SeleccionarFacturaPorCod(string codigoFACp)
        {
            return SeleccionarFactura().Where(cat => cat.FAC_COD == codigoFACp).SingleOrDefault();
        }

        [WebMethod]
        public List<FACTURA> SeleccionarFacturaPorCed(string cedulaFACp)
        {
            return SeleccionarFactura().Where(cat => cat.CLI_CEDULA == cedulaFACp).ToList();
        }

        [WebMethod]
        #region metodos de accion
        public string insertarFactura(string facCod, string cliCedula, string venCedula, DateTime facFecha, string facEstado)
        {
            FACTURA nuevaFactura = new FACTURA
            {
                FAC_COD = facCod,
                CLI_CEDULA = cliCedula,
                VEN_CEDULA = venCedula,
                FAC_FECHA = facFecha,
                FAC_ESTADO = facEstado
            };
            return logicaFacturas.insertarFactura(nuevaFactura);
        }

        #endregion
        [WebMethod]
        public string modificarFactura(string facCod, string cliCedula, string venCedula, DateTime facFecha, string facEstado)
        {
            FACTURA facturaModificada = new FACTURA
            {
                FAC_COD = facCod,
                CLI_CEDULA = cliCedula,
                VEN_CEDULA = venCedula,
                FAC_FECHA = facFecha,
                FAC_ESTADO = facEstado
            };
            return logicaFacturas.modificarFactura(facturaModificada);
        }


        [WebMethod]
        public string eliminarFactura(string facCod)
        {
            return logicaFacturas.eliminarFactura(facCod);
        }
    }
}
