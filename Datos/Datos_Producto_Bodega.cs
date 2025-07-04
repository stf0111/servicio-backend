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
    public class Datos_Producto_Bodega
    {
        EntitiesSuple _contexto;

        public Datos_Producto_Bodega()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public List<PRODUCTO_BODEGA> SeleccionarProductoBodega()
        {
            return _contexto.PRODUCTO_BODEGA.ToList();
        }

        #region metodos de accion

        public string insertarProductoBodega(PRODUCTO_BODEGA nuevoProductoBodega)
        {
            _contexto.PRODUCTO_BODEGA.Add(nuevoProductoBodega);
            _contexto.SaveChanges();
            return $"Producto {nuevoProductoBodega.PROD_CODIGO} insertado en bodega {nuevoProductoBodega.BOD_COD}";
        }

        public string modificarProductoBodega(PRODUCTO_BODEGA productoBodegaModificado)
        {
            var productoBodega = _contexto.PRODUCTO_BODEGA.FirstOrDefault(pb => pb.PROD_CODIGO == productoBodegaModificado.PROD_CODIGO && pb.BOD_COD == productoBodegaModificado.BOD_COD);
            if (productoBodega != null)
            {
                productoBodega.PRBO_CANTIDAD = productoBodegaModificado.PRBO_CANTIDAD;
                _contexto.SaveChanges();
                return $"Producto {productoBodega.PROD_CODIGO} en bodega {productoBodega.BOD_COD} actualizado";
            }
            return "Producto en bodega no encontrado";
        }

        public string eliminarProductoBodega(string prodCodigo, string bodegaCodigo)
        {
            try
            {
                var productoBodega = _contexto.PRODUCTO_BODEGA.FirstOrDefault(pb => pb.PROD_CODIGO == prodCodigo && pb.BOD_COD == bodegaCodigo);
                if (productoBodega != null)
                {
                    _contexto.PRODUCTO_BODEGA.Remove(productoBodega);
                    _contexto.SaveChanges();
                    return $"Producto {prodCodigo} eliminado de bodega {bodegaCodigo}";
                }
                return "Producto en bodega no encontrado";
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    return "No se puede eliminar el producto de la bodega debido a restricciones de integridad.";
                }
                return "Error al eliminar el producto de la bodega.";
            }
            catch (Exception ex)
            {
                return "Error al procesar la solicitud de eliminación.";
            }
        }

        #endregion
    }
}
