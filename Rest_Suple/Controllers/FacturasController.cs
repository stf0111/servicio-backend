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

    public class FacturasController : ApiController
    {
        Logica_Facturas op = new Logica_Facturas();

        // GET: api/Facturas
        [HttpGet]
        public List<FACTURA> Get()
        {
            return op.SeleccionarFactura();
        }

        // GET: api/Facturas/5
        [HttpGet]
        public FACTURA GetByCodigo(string id)
        {
            return op.SeleccionarFacturaPorCod(id);
        }

        // GET: api/Facturas/cedula/5
        [HttpGet]
        [Route("api/Facturas/cedula/{cedula}")]
        public FACTURA GetByCedula(string cedula)
        {
            return op.SeleccionarFacturaPorCed(cedula);
        }

        // POST: api/Facturas
        [HttpPost]
        public string Post([FromBody] FACTURA nuevaFactura)
        {
            return op.insertarFactura(nuevaFactura);
        }

        // PUT: api/Facturas/5
        [HttpPut]
        public string Put([FromBody] FACTURA facturaModificada)
        {
            return op.modificarFactura(facturaModificada);
        }

        // DELETE: api/Facturas/5
        [HttpDelete]
        public string Delete(string id)
        {
            return op.eliminarFactura(id);
        }
    }
}
