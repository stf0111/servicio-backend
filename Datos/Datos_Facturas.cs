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
    public class Datos_Facturas
    {
        EntitiesSuple _contexto;

        public Datos_Facturas()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;

        }

        public List<FACTURA> SeleccionarFactura()
        {
            return _contexto.FACTURA.ToList();

        }

        #region metodos de accion

        public string insertarFactura(FACTURA nuevaFactura)
        {
            _contexto.FACTURA.Add(nuevaFactura);
            _contexto.SaveChanges();
            return nuevaFactura.FAC_COD;

        }
        public string modificarFactura(FACTURA facturaModificado)
        {
            var factura = _contexto.FACTURA.FirstOrDefault(c => c.FAC_COD == facturaModificado.FAC_COD);
            if (factura != null)
            {
                factura.FAC_COD = facturaModificado.FAC_COD;
                factura.CLI_CEDULA = facturaModificado.CLI_CEDULA;
                factura.VEN_CEDULA = facturaModificado.VEN_CEDULA;
                factura.FAC_FECHA = facturaModificado.FAC_FECHA;
                factura.FAC_ESTADO = facturaModificado.FAC_ESTADO;

                _contexto.SaveChanges();
                return factura.FAC_COD;  // Devuelve la cédula al modificar
            }
            return "No encontrado";  // Informa que no se encontró el cliente
        }

        public string eliminarFactura(string codigo)
        {
            try
            {
                var factura = _contexto.FACTURA.FirstOrDefault(c => c.FAC_COD == codigo);
                if (factura != null)
                {
                    _contexto.FACTURA.Remove(factura);
                    _contexto.SaveChanges();
                    return factura.FAC_COD;  // Devuelve el código al eliminar
                }
                return "No encontrado";  // Informa que no se encontró la factura
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    // Aquí puedes agregar lógica específica basada en el número de error de SQL si es necesario
                    return "No se puede eliminar la factura porque está en uso o hay restricciones de integridad.";
                }
                return "Error al eliminar la factura debido a un problema con la base de datos.";
            }
            catch (Exception ex)
            {
                // Este es un bloque de captura general para cualquier otro tipo de excepción no prevista
                return "Error al procesar la solicitud de eliminación.";
            }
        }


        #endregion
    }
}
