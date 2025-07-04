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

    public class Producto_ProveedorController : ApiController
    {

        private Logica_Producto_Proveedor op = new Logica_Producto_Proveedor();

        // GET: api/ProductoProveedor
        [HttpGet]
        public IHttpActionResult Get()
        {
            var productosProveedores = op.SeleccionarProductoProveedor();
            if (productosProveedores == null || productosProveedores.Count == 0)
                return NotFound();
            return Ok(productosProveedores);
        }

        // GET: api/ProductoProveedor/prod/5
        [HttpGet]
        [Route("api/producto_proveedor/prod/{prodCodigo}")]
        public IHttpActionResult GetByProdCodigo(string prodCodigo)
        {
            var productosProveedores = op.SeleccionarProductoProveedorPorCodigoProducto(prodCodigo);
            if (productosProveedores == null || productosProveedores.Count == 0)
                return NotFound();
            return Ok(productosProveedores);
        }

        // GET: api/ProductoProveedor/prov/5
        [HttpGet]
        [Route("api/producto_proveedor/prov/{provCodigo}")]
        public IHttpActionResult GetByProvCodigo(string provCodigo)
        {
            var productosProveedores = op.SeleccionarProductoProveedorPorCodigoProveedor(provCodigo);
            if (productosProveedores == null || productosProveedores.Count == 0)
                return NotFound();
            return Ok(productosProveedores);
        }

        // POST: api/ProductoProveedor
        [HttpPost]
        public IHttpActionResult Post([FromBody] PRODUCTO_PROVEEDOR nuevoProductoProveedor)
        {
            if (nuevoProductoProveedor == null)
                return BadRequest("Invalid data.");
            var result = op.InsertarProductoProveedor(nuevoProductoProveedor.PROD_CODIGO, nuevoProductoProveedor.PROV_COD, nuevoProductoProveedor.OBSERVACIONES);
            if (result.ToLower().Contains("asignado"))
                return Created(new System.Uri(Request.RequestUri + "/" + nuevoProductoProveedor.PROD_CODIGO), result);
            else
                return BadRequest(result);
        }

        // PUT: api/ProductoProveedor/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] PRODUCTO_PROVEEDOR productoProveedorModificado)
        {
            if (productoProveedorModificado == null)
                return BadRequest("Invalid data.");
            var result = op.ModificarProductoProveedor(productoProveedorModificado.PROD_CODIGO, productoProveedorModificado.PROV_COD, productoProveedorModificado.OBSERVACIONES);
            if (result.ToLower().Contains("actualizado"))
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE: api/ProductoProveedor?prodCodigo=5&provCodigo=10
        //https://localhost:44368/api/producto_proveedor?prodCodigo=PROD0001&provCodigo=PROV0002

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] string prodCodigo, [FromUri] string provCodigo)
        {
            var result = op.EliminarProductoProveedor(prodCodigo, provCodigo);
            if (result.ToLower().Contains("desvinculado"))
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
