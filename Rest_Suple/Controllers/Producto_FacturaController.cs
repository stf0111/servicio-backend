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

    public class Producto_FacturaController : ApiController
    {
        Logica_Producto_Factura op = new Logica_Producto_Factura();

        // GET: api/ProductoFactura
        [HttpGet]

        public List<PRODUCTO_FACTURA> Get()
        {
            return op.SeleccionarProductoFactura();
        }


        // GET: api/ProductoFactura/5
        [HttpGet]
        [Route("api/producto_factura/{facCodigo}")]  // Ensure this route template is correct
        public List<PRODUCTO_FACTURA> Get(string facCodigo)
        {
            return op.SeleccionarProductoFacturaPorCodigo(facCodigo);
        }


        // POST: api/ProductoFactura
        [HttpPost]
        public IHttpActionResult Post([FromBody] PRODUCTO_FACTURA nuevoProductoFactura)
        {
            if (nuevoProductoFactura == null)
                return BadRequest("Invalid data.");

            var result = op.InsertarProductoFactura(
                nuevoProductoFactura.PROD_CODIGO,
                nuevoProductoFactura.FAC_COD,
                (int)nuevoProductoFactura.FP_CANTIDAD,
                (decimal)nuevoProductoFactura.FP_PRECIO);

            if (result.Contains("insertado"))
                return Created(new System.Uri(Request.RequestUri + "/" + nuevoProductoFactura.PROD_CODIGO), result);
            else
                return BadRequest(result);
        }

        // PUT: api/ProductoFactura/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] PRODUCTO_FACTURA productoFacturaModificado)
        {
            if (productoFacturaModificado == null)
                return BadRequest("Invalid data.");

            var result = op.ModificarProductoFactura(
                productoFacturaModificado.PROD_CODIGO,
                productoFacturaModificado.FAC_COD,
                (int)productoFacturaModificado.FP_CANTIDAD,
                (decimal)productoFacturaModificado.FP_PRECIO);

            if (result.Contains("actualizado"))
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE: api/ProductoFactura?prodCodigo={prodCodigo}&facCodigo={facCodigo}
        //https://localhost:44368/api/producto_factura?prodCodigo=PROD0001&facCodigo=0000000459
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] string prodCodigo, [FromUri] string facCodigo)
        {
            var result = op.EliminarProductoFactura(prodCodigo, facCodigo);
            if (result.Contains("eliminado"))
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

