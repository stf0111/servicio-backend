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
    public class ProductosController : ApiController
    {
        Logica_Productos op = new Logica_Productos();

        // GET: api/Productos
        [HttpGet]
        public List<PRODUCTO> Get()
        {
            return op.SeleccionarProducto();
        }

        // GET: api/Productos/5
        [HttpGet]
        public PRODUCTO Get(string id)
        {
            return op.SeleccionarProductoPorCod(id);
        }

        // GET: api/Productos/porMarca
        [HttpGet]
        [Route("api/Productos/porMarca/{marca}")]
        public List<PRODUCTO> GetPorMarca(string marca)
        {
            return op.SeleccionarProductoPorMarca(marca);
        }

        // GET: api/Productos/porTipo
        [HttpGet]
        [Route("api/Productos/porTipo/{tipo}")]
        public List<PRODUCTO> GetPorTipo(string tipo)
        {
            return op.SeleccionarProductoPorTipo(tipo);
        }

        // POST: api/Productos
        [HttpPost]
        public IHttpActionResult Post([FromBody] PRODUCTO nuevoProducto)
        {
            var resultado = op.insertarProducto(nuevoProducto);
            if (resultado == null)
                return BadRequest("Error al insertar producto.");
            return Ok(resultado);
        }

        // PUT: api/Productos/5
        [HttpPut]
        public IHttpActionResult Put(string id, [FromBody] PRODUCTO productoModificado)
        {
            if (id != productoModificado.PROD_CODIGO)
                return BadRequest("El código del producto no coincide.");

            var resultado = op.modificarProducto(productoModificado);
            if (resultado == null)
                return BadRequest("Producto no encontrado.");
            return Ok(resultado);
        }

        // DELETE: api/Productos/5
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var resultado = op.eliminarProducto(id);
            if (resultado == null)
                return BadRequest("Producto no encontrado.");
            return Ok(resultado);
        }
    }

}
