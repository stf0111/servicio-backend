using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Datos_Clientes
    {
        EntitiesSuple _contexto;

        public Datos_Clientes()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;

        }

        public List<CLIENTE> SeleccionarCliente()
        {
            return _contexto.CLIENTE.ToList();

        }

        #region metodos de accion

        public string insertarCliente(CLIENTE nuevoCliente)
        {
            _contexto.CLIENTE.Add(nuevoCliente);
            _contexto.SaveChanges();
            return nuevoCliente.CLI_CEDULA;

        }

        public string modificarCliente(CLIENTE clienteModificado)
        {
            var cliente = _contexto.CLIENTE.FirstOrDefault(c => c.CLI_CEDULA == clienteModificado.CLI_CEDULA);
            if (cliente != null)
            {
                cliente.CLI_NOMBRE = clienteModificado.CLI_NOMBRE;
                cliente.CLI_APELLIDO = clienteModificado.CLI_APELLIDO;
                cliente.CLI_DIRECCION = clienteModificado.CLI_DIRECCION;
                cliente.CLI_CORREO = clienteModificado.CLI_CORREO;
                cliente.CLI_TELEFONO = clienteModificado.CLI_TELEFONO;

                _contexto.SaveChanges();
                return cliente.CLI_CEDULA;  // Retorna la cédula del cliente modificado
            }
            return "No encontrado";  // Si no se encuentra el cliente
        }

        public string eliminarCliente(string cedula)
        {
            try
            {
                var cliente = _contexto.CLIENTE.FirstOrDefault(c => c.CLI_CEDULA == cedula);
                if (cliente != null)
                {
                    _contexto.CLIENTE.Remove(cliente);
                    _contexto.SaveChanges();
                    return cliente.CLI_CEDULA;  // Devuelve la cédula al eliminar
                }
                return "No encontrado";  // Informa que no se encontró el cliente
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    // Aquí puedes agregar lógica específica basada en el número de error de SQL si es necesario
                    return "No se puede eliminar el cliente porque está en uso o hay restricciones de integridad.";
                }
                return "Error al eliminar el cliente debido a un problema con la base de datos.";
            }
            catch (Exception ex)
            {
                // Este es un bloque de captura general para cualquier otro tipo de excepción no prevista
                return "Error al procesar la solicitud de eliminación.";
            }
        }

        #endregion
    }
}
