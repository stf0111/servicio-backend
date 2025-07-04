using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Datos_Reportes
    {
        EntitiesSuple _contexto;

        public Datos_Reportes()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;

        }

        public List<GetTopVendedorPorMes_Result> GetTopVendedorPorMes(int year, int month)
        {
            try
            {
                return _contexto.Database.SqlQuery<GetTopVendedorPorMes_Result>(
                    "EXEC GetTopVendedorPorMes @Year, @Month",
                    new SqlParameter("Year", year),
                    new SqlParameter("Month", month)
                ).ToList();
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately
                throw new InvalidOperationException("Error fetching top vendor for the month.", ex);
            }
        }


        public List<ProductosMasVendidos_Result> ProductosMasVendidos()
        {
            return _contexto.Database.SqlQuery<ProductosMasVendidos_Result>(
                "EXEC ProductosMasVendidos"
            ).ToList();
        }

        public List<ProductosMenosVendidos_Result> ProductosMenosVendidos()
        {
            return _contexto.Database.SqlQuery<ProductosMenosVendidos_Result>(
                "EXEC ProductosMenosVendidos"
            ).ToList();
        }

        public List<ProveedoresConMasVentas_Result> ProveedoresConMasVentas()
        {
            return _contexto.Database.SqlQuery<ProveedoresConMasVentas_Result>(
                "EXEC ProveedoresConMasVentas"
            ).ToList();
        }

        public List<Proc_Productos_Caducar_Result> ProductosPorCaducar()
        {
            return _contexto.Database.SqlQuery<Proc_Productos_Caducar_Result>(
                "EXEC Proc_Productos_Caducar"
            ).ToList();
        }

        public Proc_Ganancia_Mensual_Result CalcularGananciaMensual(int year, int month)
        {
            return _contexto.Database.SqlQuery<Proc_Ganancia_Mensual_Result>(
                "EXEC Proc_Ganancia_Mensual @Year, @Month",
                new SqlParameter("Year", year),
                new SqlParameter("Month", month)
            ).FirstOrDefault();
        }

        public List<Proc_ProductosVendidosPorFecha_Result> ProductosVendidosPorFecha(int? year, int? month)
        {
            return _contexto.Database.SqlQuery<Proc_ProductosVendidosPorFecha_Result>(
                "EXEC Proc_ProductosVendidosPorFecha @Year, @Month",
                new SqlParameter("Year", (object)year ?? DBNull.Value),
                new SqlParameter("Month", (object)month ?? DBNull.Value)
            ).ToList();
        }
        public List<Proc_Ingresos_Mes_Anio_Result> ObtenerIngresosPorMesYAnio()
        {
            return _contexto.Database.SqlQuery<Proc_Ingresos_Mes_Anio_Result>("EXEC Proc_Ingresos_Mes_Anio").ToList();
        }

        public List<Proc_Inventario_Total_Result> ObtenerInventarioTotal()
        {
            return _contexto.Database.SqlQuery<Proc_Inventario_Total_Result>("EXEC Proc_Inventario_Total").ToList();
        }
    }
}
