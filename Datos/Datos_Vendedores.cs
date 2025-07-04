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
    public class Datos_Vendedores
    {
        EntitiesSuple _contexto;

        public Datos_Vendedores()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public List<VENDEDOR> SeleccionarVendedor()
        {
            return _contexto.VENDEDOR.ToList();
        }

        #region metodos de accion

        public string insertarVendedor(VENDEDOR nuevoVendedor)
        {
            _contexto.VENDEDOR.Add(nuevoVendedor);
            _contexto.SaveChanges();
            return nuevoVendedor.VEN_CEDULA;  // Asumiendo que VEN_CEDULA es el identificador
        }

        public string modificarVendedor(VENDEDOR vendedorModificado)
        {
            var vendedor = _contexto.VENDEDOR.FirstOrDefault(v => v.VEN_CEDULA == vendedorModificado.VEN_CEDULA);
            if (vendedor != null)
            {
                vendedor.VEN_NOMBRE = vendedorModificado.VEN_NOMBRE;
                vendedor.VEN_APELLIDO = vendedorModificado.VEN_APELLIDO;
                vendedor.VEN_TELEFONO = vendedorModificado.VEN_TELEFONO;
                vendedor.VEN_COMISION = vendedorModificado.VEN_COMISION;  // Asumiendo que esta propiedad existe
                _contexto.SaveChanges();
                return vendedor.VEN_CEDULA;
            }
            return "No encontrado";
        }

        public string eliminarVendedor(string cedula)
        {
            try
            {
                var vendedor = _contexto.VENDEDOR.FirstOrDefault(v => v.VEN_CEDULA == cedula);
                if (vendedor != null)
                {
                    _contexto.VENDEDOR.Remove(vendedor);
                    _contexto.SaveChanges();
                    return vendedor.VEN_CEDULA;
                }
                return "No encontrado";
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    return "No se puede eliminar el vendedor porque está en uso o hay restricciones de integridad.";
                }
                return "Error al eliminar el vendedor debido a un problema con la base de datos.";
            }
            catch (Exception ex)
            {
                return "Error al procesar la solicitud de eliminación.";
            }
        }

        #endregion
    }
}
