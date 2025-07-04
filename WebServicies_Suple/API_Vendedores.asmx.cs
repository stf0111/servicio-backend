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
    /// Descripción breve de API_Vendedores
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Vendedores : System.Web.Services.WebService
    {

        Logica_Vendedores logicaVendedores = new Logica_Vendedores();

        [WebMethod]
        public List<VENDEDOR> SeleccionarVendedor()
        {
            return logicaVendedores.SeleccionarVendedor();
        }

        [WebMethod]
        public VENDEDOR SeleccionarVendedorPorCedula(string cedula)
        {
            return logicaVendedores.SeleccionarVendedorPorCedula(cedula);
        }

        [WebMethod]
        public string InsertarVendedor(string venCedula, string venNombre, string venApellido, decimal venComision, string venTelefono)
        {
            VENDEDOR nuevoVendedor = new VENDEDOR
            {
                VEN_CEDULA = venCedula,
                VEN_NOMBRE = venNombre,
                VEN_APELLIDO = venApellido,
                VEN_COMISION = venComision,
                VEN_TELEFONO = venTelefono
            };
            return logicaVendedores.insertarVendedor(nuevoVendedor);
        }

        [WebMethod]
        public string ModificarVendedor(string venCedula, string venNombre, string venApellido, decimal venComision, string venTelefono)
        {
            VENDEDOR vendedorModificado = new VENDEDOR
            {
                VEN_CEDULA = venCedula,
                VEN_NOMBRE = venNombre,
                VEN_APELLIDO = venApellido,
                VEN_COMISION = venComision,
                VEN_TELEFONO = venTelefono
            };
            return logicaVendedores.modificarVendedor(vendedorModificado);
        }

        [WebMethod]
        public string EliminarVendedor(string cedula)
        {
            return logicaVendedores.eliminarVendedor(cedula);
        }
    }
}
