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
    /// Descripción breve de API_Proveedores
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Proveedores : System.Web.Services.WebService
    {

        Logica_Proveedores logicaProveedores = new Logica_Proveedores();

        [WebMethod]
        public List<PROVEEDOR> SeleccionarProveedores()
        {
            return logicaProveedores.SeleccionarProveedores();
        }

        [WebMethod]
        public PROVEEDOR SeleccionarProveedorPorCodigo(string provCod)
        {
            return logicaProveedores.SeleccionarProveedorPorCodigo(provCod);
        }

        [WebMethod]
        public string InsertarProveedor(string provCod, string provNomEmp, string provTelefono, string provDireccion, string provCorreo, string provVendedor)
        {
            PROVEEDOR nuevoProveedor = new PROVEEDOR
            {
                PROV_COD = provCod,
                PROV_NOMEMP = provNomEmp,
                PROV_TELEFONO = provTelefono,
                PROV_DIRECCION = provDireccion,
                PROV_CORREO = provCorreo,
                PROV_VENDEDOR = provVendedor
            };
            return logicaProveedores.insertarProveedor(nuevoProveedor);
        }

        [WebMethod]
        public string ModificarProveedor(string provCod, string provNomEmp, string provTelefono, string provDireccion, string provCorreo, string provVendedor)
        {
            PROVEEDOR proveedorModificado = new PROVEEDOR
            {
                PROV_COD = provCod,
                PROV_NOMEMP = provNomEmp,
                PROV_TELEFONO = provTelefono,
                PROV_DIRECCION = provDireccion,
                PROV_CORREO = provCorreo,
                PROV_VENDEDOR = provVendedor
            };
            return logicaProveedores.modificarProveedor(proveedorModificado);
        }

        [WebMethod]
        public string EliminarProveedor(string provCod)
        {
            return logicaProveedores.eliminarProveedor(provCod);
        }
    }
}

