using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Datos_Bodegas
    {

        private EntitiesSuple _contexto;

        public Datos_Bodegas()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public List<BODEGA> SeleccionarBodegas()
        {
            return _contexto.BODEGA.ToList();
        }

        public string insertarBodega(BODEGA nuevaBodega)
        {
            _contexto.BODEGA.Add(nuevaBodega);
            _contexto.SaveChanges();
            return nuevaBodega.BOD_COD;  // Suponiendo que BOD_COD es el código único de la bodega.
        }

        public string modificarBodega(BODEGA bodegaModificada)
        {
            var bodega = _contexto.BODEGA.FirstOrDefault(b => b.BOD_COD == bodegaModificada.BOD_COD);
            if (bodega != null)
            {
                bodega.BOD_NOMBRE = bodegaModificada.BOD_NOMBRE;
                _contexto.SaveChanges();
                return bodega.BOD_COD;
            }
            return "No encontrado";  // Indicar que no se encontró la bodega.
        }

        public string eliminarBodega(string codigo)
        {
            try
            {
                var bodega = _contexto.BODEGA.FirstOrDefault(b => b.BOD_COD == codigo);
                if (bodega != null)
                {
                    _contexto.BODEGA.Remove(bodega);
                    _contexto.SaveChanges();
                    return bodega.BOD_COD;  // Devuelve el código al eliminar.
                }
                return "No encontrado";  // Indicar que no se encontró la bodega.
            }
            catch (DbUpdateException ex)
            {
                // Este bloque captura excepciones específicas de la base de datos, como errores de integridad referencial.
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    // Aquí puedes manejar diferentes números de error de SQL Server si es necesario.
                    return $"No se puede eliminar la bodega: {sqlEx.Message}";
                }
                return "Error al eliminar la bodega debido a un problema con la base de datos.";
            }
            catch (Exception ex)
            {
                // Captura cualquier otro tipo de excepción que pueda ocurrir.
                return $"Error al procesar la solicitud de eliminación: {ex.Message}";
            }
        }
    }
}
