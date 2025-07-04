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
    public class ProveedoresController : ApiController
    {
        private Logica_Proveedores op = new Logica_Proveedores();

        // GET: api/Proveedores
        [HttpGet]
        public IHttpActionResult Get()
        {
            var proveedores = op.SeleccionarProveedores();
            if (proveedores == null || proveedores.Count == 0)
                return NotFound();
            return Ok(proveedores);
        }

        // GET: api/Proveedores/5
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var proveedor = op.SeleccionarProveedorPorCodigo(id);
            if (proveedor == null)
                return NotFound();
            return Ok(proveedor);
        }

        // POST: api/Proveedores
        [HttpPost]
        public IHttpActionResult Post([FromBody] PROVEEDOR nuevoProveedor)
        {
            if (nuevoProveedor == null)
                return BadRequest("Invalid data.");

            var result = op.insertarProveedor(nuevoProveedor);
            if (!string.IsNullOrEmpty(result))
                return Created(new System.Uri(Request.RequestUri + "/" + result), result);
            else
                return BadRequest("Failed to create provider.");
        }

        // PUT: api/Proveedores/5
        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] PROVEEDOR proveedorModificado)
        {
            if (proveedorModificado == null)
                return BadRequest("Invalid data.");

            proveedorModificado.PROV_COD = id; // Ensure the ID is set correctly based on the route
            var result = op.modificarProveedor(proveedorModificado);
            if (!string.IsNullOrEmpty(result))
                return Ok("Provider updated successfully.");
            else
                return NotFound();
        }

        // DELETE: api/Proveedores/5
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var result = op.eliminarProveedor(id);
            if (result != "No encontrado")
                return Ok($"Provider {id} deleted successfully.");
            else
                return BadRequest("Provider not found or could not be deleted.");
        }
    }

}
