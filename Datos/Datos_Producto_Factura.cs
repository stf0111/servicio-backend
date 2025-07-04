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
    public class Datos_Producto_Factura
    {
        EntitiesSuple _contexto;

        public Datos_Producto_Factura()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public List<PRODUCTO_FACTURA> SeleccionarProductoFactura()
        {
            return _contexto.PRODUCTO_FACTURA.ToList();
        }

        #region metodos de accion

        public string insertarProductoFactura(PRODUCTO_FACTURA nuevoProductoFactura)
        {
            _contexto.PRODUCTO_FACTURA.Add(nuevoProductoFactura);
            _contexto.SaveChanges();
            return $"Producto {nuevoProductoFactura.PROD_CODIGO} insertado en factura {nuevoProductoFactura.FAC_COD}";
        }

        public string modificarProductoFactura(PRODUCTO_FACTURA productoFacturaModificado)
        {
            var productoFactura = _contexto.PRODUCTO_FACTURA.FirstOrDefault(pf => pf.PROD_CODIGO == productoFacturaModificado.PROD_CODIGO && pf.FAC_COD == productoFacturaModificado.FAC_COD);
            if (productoFactura != null)
            {
                productoFactura.FP_CANTIDAD = productoFacturaModificado.FP_CANTIDAD;
                productoFactura.FP_PRECIO = productoFacturaModificado.FP_PRECIO;
                _contexto.SaveChanges();
                return $"Producto {productoFactura.PROD_CODIGO} en factura {productoFactura.FAC_COD} actualizado";
            }
            return "Producto en factura no encontrado";
        }

        public string eliminarProductoFactura(string prodCodigo, string facCodigo)
        {
            try
            {
                var productoFactura = _contexto.PRODUCTO_FACTURA.FirstOrDefault(pf => pf.PROD_CODIGO == prodCodigo && pf.FAC_COD == facCodigo);
                if (productoFactura != null)
                {
                    _contexto.PRODUCTO_FACTURA.Remove(productoFactura);
                    _contexto.SaveChanges();
                    return $"Producto {prodCodigo} eliminado de factura {facCodigo}";
                }
                return "Producto en factura no encontrado";
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    return "No se puede eliminar el producto de la factura debido a restricciones de integridad.";
                }
                return "Error al eliminar el producto de la factura.";
            }
            catch (Exception ex)
            {
                return "Error al procesar la solicitud de eliminación.";
            }
        }

        #endregion
    }
}
