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

    public class VendedoresController : ApiController
    {
        private Logica_Vendedores op = new Logica_Vendedores();

        // GET: api/Vendedores
        [HttpGet]
        public IHttpActionResult Get()
        {
            var vendedores = op.SeleccionarVendedor();
            if (vendedores == null || vendedores.Count == 0)
                return NotFound();
            return Ok(vendedores);
        }

        // GET: api/Vendedores/5
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var vendedor = op.SeleccionarVendedorPorCedula(id);
            if (vendedor == null)
                return NotFound();
            return Ok(vendedor);
        }

        // POST: api/Vendedores
        [HttpPost]
        public IHttpActionResult Post([FromBody] VENDEDOR nuevoVendedor)
        {
            if (nuevoVendedor == null)
                return BadRequest("Invalid data.");

            var result = op.insertarVendedor(nuevoVendedor);
            if (!string.IsNullOrEmpty(result))
                return Created(new System.Uri(Request.RequestUri + "/" + result), result);
            else
                return BadRequest("Failed to create vendor.");
        }

        // PUT: api/Vendedores/5
        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] VENDEDOR vendedorModificado)
        {
            if (vendedorModificado == null || vendedorModificado.VEN_CEDULA != id)
                return BadRequest("Invalid data.");

            var result = op.modificarVendedor(vendedorModificado);
            if (result.Equals("No encontrado"))
                return NotFound();
            else if (!string.IsNullOrEmpty(result))
                return Ok("Vendor updated successfully.");
            else
                return BadRequest("Error updating vendor.");
        }

        // DELETE: api/Vendedores/5
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var result = op.eliminarVendedor(id);
            if (result.Equals("No encontrado"))
                return NotFound();
            else if (!string.IsNullOrEmpty(result))
                return Ok($"Vendor {id} deleted successfully.");
            else
                return BadRequest("Error deleting vendor.");
        }
    }
}
