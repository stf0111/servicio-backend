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
    public class Datos_Proveedores
    {
        EntitiesSuple _contexto;

        public Datos_Proveedores()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public List<PROVEEDOR> SeleccionarProveedores()
        {
            return _contexto.PROVEEDOR.ToList();
        }

        #region metodos de accion

        public string insertarProveedor(PROVEEDOR nuevoProveedor)
        {
            _contexto.PROVEEDOR.Add(nuevoProveedor);
            _contexto.SaveChanges();
            return nuevoProveedor.PROV_COD;  // Asumiendo que PROV_COD es la clave primaria
        }

        public string modificarProveedor(PROVEEDOR proveedorModificado)
        {
            var proveedor = _contexto.PROVEEDOR.FirstOrDefault(p => p.PROV_COD == proveedorModificado.PROV_COD);
            if (proveedor != null)
            {
                proveedor.PROV_NOMEMP = proveedorModificado.PROV_NOMEMP;
                proveedor.PROV_TELEFONO = proveedorModificado.PROV_TELEFONO;
                proveedor.PROV_DIRECCION = proveedorModificado.PROV_DIRECCION;
                proveedor.PROV_CORREO = proveedorModificado.PROV_CORREO;
                proveedor.PROV_VENDEDOR = proveedorModificado.PROV_VENDEDOR;
                _contexto.SaveChanges();
                return proveedor.PROV_COD;
            }
            return "No encontrado";
        }

        public string eliminarProveedor(string codigo)
        {
            try
            {
                var proveedor = _contexto.PROVEEDOR.FirstOrDefault(p => p.PROV_COD == codigo);
                if (proveedor != null)
                {
                    _contexto.PROVEEDOR.Remove(proveedor);
                    _contexto.SaveChanges();
                    return proveedor.PROV_COD;
                }
                return "No encontrado";
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    return "No se puede eliminar el proveedor porque está en uso o hay restricciones de integridad.";
                }
                return "Error al eliminar el proveedor debido a un problema con la base de datos.";
            }
            catch (Exception ex)
            {
                return "Error al procesar la solicitud de eliminación.";
            }
        }

        #endregion
    }
}
