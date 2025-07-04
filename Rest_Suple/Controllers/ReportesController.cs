using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rest_Suple.Controllers
{
    public class ReportesController : ApiController
    {
        private Logica_Reportes _logicaReportes;

        public ReportesController()
        {
            _logicaReportes = new Logica_Reportes();
        }

        [HttpGet]
        [Route("api/reportes/mejorVendedorPorMes/{year}/{month}")]
        public IHttpActionResult GetMejorVendedorPorMes(int year, int month)
        {
            try
            {
                var results = _logicaReportes.ObtenerMejorVendedorPorMes(year, month);
                if (results == null || results.Count == 0)
                    return NotFound();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/reportes/productosMasVendidos")]
        public IHttpActionResult GetProductosMasVendidos()
        {
            try
            {
                var results = _logicaReportes.ObtenerProductosMasVendidos();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/reportes/productosMenosVendidos")]
        public IHttpActionResult GetProductosMenosVendidos()
        {
            try
            {
                var results = _logicaReportes.ObtenerProductosMenosVendidos();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/reportes/proveedoresConMasVentas")]
        public IHttpActionResult GetProveedoresConMasVentas()
        {
            try
            {
                var results = _logicaReportes.ObtenerProveedoresConMasVentas();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/reportes/productosPorCaducar")]
        public IHttpActionResult GetProductosPorCaducar()
        {
            try
            {
                var results = _logicaReportes.ObtenerProductosPorCaducar();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/reportes/gananciaMensual/{year}/{month}")]
        public IHttpActionResult GetGananciaMensual(int year, int month)
        {
            try
            {
                var result = _logicaReportes.CalcularGananciaMensual(year, month);
                if (result == null)
                    return NotFound();
                return Ok(result.GananciaNeta);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/reportes/ingresosPorMesYAnio")]
        public IHttpActionResult GetIngresosPorMesYAnio()
        {
            try
            {
                var results = _logicaReportes.ObtenerIngresosPorMesYAnio();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/reportes/inventarioTotal")]
        public IHttpActionResult GetInventarioTotal()
        {
            try
            {
                var results = _logicaReportes.ObtenerInventarioTotal();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
