using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Reportes
    {
        private Datos_Reportes _datosReportes;

        public Logica_Reportes()
        {
            _datosReportes = new Datos_Reportes();
        }

        public List<GetTopVendedorPorMes_Result> ObtenerMejorVendedorPorMes(int year, int month)
        {
            return _datosReportes.GetTopVendedorPorMes(year, month);
        }

        public List<ProductosMasVendidos_Result> ObtenerProductosMasVendidos()
        {
            return _datosReportes.ProductosMasVendidos();
        }

        public List<ProductosMenosVendidos_Result> ObtenerProductosMenosVendidos()
        {
            return _datosReportes.ProductosMenosVendidos();
        }

        public List<ProveedoresConMasVentas_Result> ObtenerProveedoresConMasVentas()
        {
            return _datosReportes.ProveedoresConMasVentas();
        }

        public List<Proc_Productos_Caducar_Result> ObtenerProductosPorCaducar()
        {
            return _datosReportes.ProductosPorCaducar();
        }

        public Proc_Ganancia_Mensual_Result CalcularGananciaMensual(int year, int month)
        {
            return _datosReportes.CalcularGananciaMensual(year, month);
        }

        public List<Proc_ProductosVendidosPorFecha_Result> ObtenerProductosVendidosPorFecha(int? year, int? month)
        {
            return _datosReportes.ProductosVendidosPorFecha(year, month);
        }

        public List<Proc_Ingresos_Mes_Anio_Result> ObtenerIngresosPorMesYAnio()
        {
            return _datosReportes.ObtenerIngresosPorMesYAnio();
        }

        public List<Proc_Inventario_Total_Result> ObtenerInventarioTotal()
        {
            return _datosReportes.ObtenerInventarioTotal();
        }
    }
}
