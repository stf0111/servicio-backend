using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Acceso_Datos.DTO; // Asegúrate de incluir el espacio de nombres donde se encuentran los DTOs si es necesario

namespace Rest_Suple.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Integracion")] // Prefijo base para este controlador

    public class IntegracionController : ApiController
    {
        Logica_Integracion op = new Logica_Integracion();


        // GET: api/Integracion/Facturas/{IdCedula}
        [HttpGet]
        [Route("Facturas/{clienteID}")]
        public List<IntegracionSuple> GetFacturas(string clienteID)
        {
            return op.Facturas(clienteID);
        }


        // GET: api/Integracion/VerificarStock/5
        [HttpGet]
        [Route("VerificarStock/{codigoFactura}")]
        public bool GetVerificarStock(string codigoFactura)
        {
            return op.VerificarStockPorFactura(codigoFactura);
        }

        // PUT: api/Integracion/ActualizarFacturaYStock/5
        [HttpGet]
        [Route("ActualizarFacturaYStock/{codigoFactura}")]
        public IHttpActionResult GetActualizarFacturaYStock(string codigoFactura)
        {
            bool resultado = op.ActualizarFacturaYStock(codigoFactura);
            // Devolver "true" o "false" según corresponda
            return Ok(resultado);
        }

    }
}
