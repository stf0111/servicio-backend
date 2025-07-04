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
    public class BodegasController : ApiController
    {
        Logica_Bodegas op = new Logica_Bodegas();

        // GET: api/Bodegas
        [HttpGet]
        public List<BODEGA> Get()
        {
            return op.SeleccionarBodegas();
        }

        // GET: api/Bodegas/5
        [HttpGet]
        public BODEGA Get(string id)
        {
            return op.SeleccionarBodegaPorCodigo(id);
        }

        // POST: api/Bodegas
        [HttpPost]
        public string Post([FromBody] BODEGA nuevaBodega)
        {
            return op.InsertarBodega(nuevaBodega);
        }

        // PUT: api/Bodegas/5
        [HttpPut]
        public string Put([FromBody] BODEGA bodegaModificada)
        {
            return op.ModificarBodega(bodegaModificada);
        }

        // DELETE: api/Bodegas/5
        [HttpDelete]
        public string Delete(string id)
        {
            return op.EliminarBodega(id);
        }
    }
}
