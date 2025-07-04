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

    public class Producto_BodegaController : ApiController
    {
        Logica_Producto_Bodega op = new Logica_Producto_Bodega();

        // GET: api/ProductoBodega
        [HttpGet]
        public List<PRODUCTO_BODEGA> Get()
        {
            return op.SeleccionarProductoBodega();
        }

        // GET: api/ProductoBodega/{prodCodigo}
        [HttpGet]
        public List<PRODUCTO_BODEGA> Get(string id)
        {
            return op.SeleccionarProductoBodegaPorCodigo(id);
        }

        // POST: api/ProductoBodega
        [HttpPost]
        public string Post([FromBody] PRODUCTO_BODEGA nuevoProductoBodega)
        {
            return op.InsertarProductoBodega(
                nuevoProductoBodega.PROD_CODIGO,
                nuevoProductoBodega.BOD_COD,
                (int)nuevoProductoBodega.PRBO_CANTIDAD
            );
        }

        // PUT: api/ProductoBodega
        [HttpPut]
        public string Put([FromBody] PRODUCTO_BODEGA productoBodegaModificado)
        {
            return op.ModificarProductoBodega(
                productoBodegaModificado.PROD_CODIGO,
                productoBodegaModificado.BOD_COD,
                (int)productoBodegaModificado.PRBO_CANTIDAD
            );
        }

        // DELETE: api/ProductoBodega?prodCodigo={prodCodigo}&bodegaCodigo={bodegaCodigo}
        //https://localhost:44368/api/producto_bodega?prodCodigo=PROD0300&bodegaCodigo=1
        [HttpDelete]
        public string Delete([FromUri] string prodCodigo, [FromUri] string bodegaCodigo)
        {
            return op.EliminarProductoBodega(prodCodigo, bodegaCodigo);
        }


    }
}
