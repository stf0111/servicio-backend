using Acceso_Datos;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Rest_Suple.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        Logica_Clientes op = new Logica_Clientes();

        // GET: api/Clientes
        [HttpGet]
        public List<CLIENTE> Get()
        {
            return op.SeleccionarCliente();
        }

        // GET: api/Clientes/5
        [HttpGet]
        public CLIENTE Get(string id)
        {
            return op.SeleccionarClientePorClienteId(id);
        }

        // POST: api/Clientes
        [HttpPost]
        public string Post([FromBody] CLIENTE nuevoCliente)
        {
            return op.insertarCliente(
                nuevoCliente.CLI_CEDULA,
                nuevoCliente.CLI_NOMBRE,
                nuevoCliente.CLI_APELLIDO,
                nuevoCliente.CLI_DIRECCION,
                nuevoCliente.CLI_CORREO,
                nuevoCliente.CLI_TELEFONO
            );
        }

        // PUT: api/Clientes/5
        [HttpPut]
        public string Put([FromBody] CLIENTE clienteModificado)
        {
            return op.modificarCliente(
                clienteModificado.CLI_CEDULA,
                clienteModificado.CLI_NOMBRE,
                clienteModificado.CLI_APELLIDO,
                clienteModificado.CLI_DIRECCION,
                clienteModificado.CLI_CORREO,
                clienteModificado.CLI_TELEFONO
            );
        }

        // DELETE: api/Clientes/5
        [HttpDelete]
        public string Delete(string id)
        {
            return op.eliminarCliente(id);
        }
    }
}
