using Acceso_Datos;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServicies_Suple
{
    /// <summary>
    /// Descripción breve de API_Reportes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class API_Reportes : System.Web.Services.WebService
    {
        Logica_Reportes _logicaReportes = new Logica_Reportes();

        [WebMethod]
        public List<GetTopVendedorPorMes_Result> ObtenerMejorVendedorPorMes(int year, int month)
        {
            return _logicaReportes.ObtenerMejorVendedorPorMes(year, month);
        }

        [WebMethod]
        public List<ProductosMasVendidos_Result> ObtenerProductosMasVendidos()
        {
            return _logicaReportes.ObtenerProductosMasVendidos();
        }

        [WebMethod]
        public List<ProductosMenosVendidos_Result> ObtenerProductosMenosVendidos()
        {
            return _logicaReportes.ObtenerProductosMenosVendidos();
        }

        [WebMethod]
        public List<ProveedoresConMasVentas_Result> ObtenerProveedoresConMasVentas()
        {
            return _logicaReportes.ObtenerProveedoresConMasVentas();
        }

        [WebMethod]
        public List<Proc_Productos_Caducar_Result> ObtenerProductosPorCaducar()
        {
            return _logicaReportes.ObtenerProductosPorCaducar();
        }

        [WebMethod]
        public Proc_Ganancia_Mensual_Result CalcularGananciaMensual(int year, int month)
        {
            return _logicaReportes.CalcularGananciaMensual(year, month);
        }

        [WebMethod]
        public List<Proc_ProductosVendidosPorFecha_Result> ObtenerProductosVendidosPorFecha(int? year, int? month)
        {
            return _logicaReportes.ObtenerProductosVendidosPorFecha(year, month);
        }

        [WebMethod]
        public List<Proc_Ingresos_Mes_Anio_Result> ObtenerIngresosPorMesYAnio()
        {
            return _logicaReportes.ObtenerIngresosPorMesYAnio();
        }

        [WebMethod]
        public List<Proc_Inventario_Total_Result> ObtenerInventarioTotal()
        {
            return _logicaReportes.ObtenerInventarioTotal();
        }
    }
}
