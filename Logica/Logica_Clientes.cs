using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Clientes
    {
        Datos_Clientes op = new Datos_Clientes();

        public List<CLIENTE> SeleccionarCliente()
        {
            return op.SeleccionarCliente();

        }

        public CLIENTE SeleccionarClientePorClienteId(string clienteIdp)
        {
            return SeleccionarCliente().Where(cat => cat.CLI_CEDULA == clienteIdp).SingleOrDefault();
        }


        public string insertarCliente(string cliCedula, string cliNombre, string cliApellido, string cliDireccion, string cliCorreo, string cliTelefono)
        {
            CLIENTE nuevoCliente = new CLIENTE
            {
                CLI_CEDULA = cliCedula,
                CLI_NOMBRE = cliNombre,
                CLI_APELLIDO = cliApellido,
                CLI_DIRECCION = cliDireccion,
                CLI_CORREO = cliCorreo,
                CLI_TELEFONO = cliTelefono
            };
            return op.insertarCliente(nuevoCliente);  // Delegando la inserción a la capa de datos
        }

        public string modificarCliente(string cliCedula, string cliNombre, string cliApellido, string cliDireccion, string cliCorreo, string cliTelefono)
        {
            CLIENTE clienteModificado = new CLIENTE
            {
                CLI_CEDULA = cliCedula,
                CLI_NOMBRE = cliNombre,
                CLI_APELLIDO = cliApellido,
                CLI_DIRECCION = cliDireccion,
                CLI_CORREO = cliCorreo,
                CLI_TELEFONO = cliTelefono
            };
            return op.modificarCliente(clienteModificado);  // Delegando la modificación a la capa de datos
        }

        public string eliminarCliente(string cedula)
        {
            // Delega la eliminación a la capa de datos
            return op.eliminarCliente(cedula);
        }
    }
}
