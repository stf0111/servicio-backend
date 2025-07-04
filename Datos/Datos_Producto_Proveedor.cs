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
    public class Datos_Producto_Proveedor
    {
        EntitiesSuple _contexto;

        public Datos_Producto_Proveedor()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public List<PRODUCTO_PROVEEDOR> SeleccionarProductoProveedor()
        {
            return _contexto.PRODUCTO_PROVEEDOR.ToList();
        }

        #region metodos de accion

        public string insertarProductoProveedor(PRODUCTO_PROVEEDOR nuevoProductoProveedor)
        {
            _contexto.PRODUCTO_PROVEEDOR.Add(nuevoProductoProveedor);
            _contexto.SaveChanges();
            return $"Producto {nuevoProductoProveedor.PROD_CODIGO} asignado al proveedor {nuevoProductoProveedor.PROV_COD}";
        }
        public string modificarProductoProveedor(PRODUCTO_PROVEEDOR productoProveedorModificado)
        {
            var productoProveedor = _contexto.PRODUCTO_PROVEEDOR.FirstOrDefault(pp => pp.PROD_CODIGO == productoProveedorModificado.PROD_CODIGO && pp.PROV_COD == productoProveedorModificado.PROV_COD);
            if (productoProveedor != null)
            {
                // Agrega o modifica las propiedades que necesitas actualizar
                productoProveedor.OBSERVACIONES = productoProveedorModificado.OBSERVACIONES; // Asume que el campo OBSERVACIONES está presente en la entidad

                _contexto.SaveChanges();
                return $"Producto {productoProveedor.PROD_CODIGO} del proveedor {productoProveedor.PROV_COD} actualizado con observaciones";
            }
            return "Producto proveedor no encontrado";
        }


        public string eliminarProductoProveedor(string prodCodigo, string provCodigo)
        {
            try
            {
                var productoProveedor = _contexto.PRODUCTO_PROVEEDOR.FirstOrDefault(pp => pp.PROD_CODIGO == prodCodigo && pp.PROV_COD == provCodigo);
                if (productoProveedor != null)
                {
                    _contexto.PRODUCTO_PROVEEDOR.Remove(productoProveedor);
                    _contexto.SaveChanges();
                    return $"Producto {prodCodigo} desvinculado del proveedor {provCodigo}";
                }
                return "Producto proveedor no encontrado";
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    return "No se puede eliminar el producto del proveedor debido a restricciones de integridad.";
                }
                return "Error al eliminar el producto del proveedor.";
            }
            catch (Exception ex)
            {
                return "Error al procesar la solicitud de eliminación.";
            }
        }

        #endregion
    }
}
