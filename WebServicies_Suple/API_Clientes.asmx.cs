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
    /// Descripción breve de API_Clientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Clientes : System.Web.Services.WebService
    {

        Logica_Clientes logicaClientes = new Logica_Clientes();


        [WebMethod]

        public List<CLIENTE> SeleccionarCliente()
        {
            return logicaClientes.SeleccionarCliente();

        }

        [WebMethod]
        public CLIENTE SeleccionarClientePorClienteId(string clienteIdp)
        {
            return SeleccionarCliente().Where(cat => cat.CLI_CEDULA == clienteIdp).SingleOrDefault();
        }


        [WebMethod]
        #region metodos de accion

        public string InsertarCliente(string cliCedula, string cliNombre, string cliApellido, string cliDireccion, string cliCorreo, string cliTelefono)
        {
            return logicaClientes.insertarCliente(cliCedula, cliNombre, cliApellido, cliDireccion, cliCorreo, cliTelefono);
        }

        #endregion
        [WebMethod]
        public string ModificarCliente(string cliCedula, string cliNombre, string cliApellido, string cliDireccion, string cliCorreo, string cliTelefono)
        {
            return logicaClientes.modificarCliente(cliCedula, cliNombre, cliApellido, cliDireccion, cliCorreo, cliTelefono);
        }


        [WebMethod]
        public string eliminarCliente(string cedula)
        {
            return logicaClientes.eliminarCliente(cedula);
        }
    }
}
