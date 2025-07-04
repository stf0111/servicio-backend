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
    public class Datos_Productos
    {
        EntitiesSuple _contexto;

        public Datos_Productos()
        {
            _contexto = new EntitiesSuple();
            _contexto.Configuration.ProxyCreationEnabled = false;

        }

        public List<PRODUCTO> SeleccionarProducto()
        {
            return _contexto.PRODUCTO.ToList();

        }

        #region metodos de accion

        public string insertarProducto(PRODUCTO nuevoProductop)
        {
            _contexto.PRODUCTO.Add(nuevoProductop);
            _contexto.SaveChanges();
            return nuevoProductop.PROD_CODIGO;

        }
        public string modificarProducto(PRODUCTO productoModificadop)
        {
            var producto = _contexto.PRODUCTO.FirstOrDefault(c => c.PROD_CODIGO == productoModificadop.PROD_CODIGO);
            if (producto != null)
            {
                producto.PROD_CODIGO = productoModificadop.PROD_CODIGO;
                producto.PROD_NOMBRE = productoModificadop.PROD_NOMBRE;
                producto.PROD_TIPO = productoModificadop.PROD_TIPO;
                producto.PROD_MARCA = productoModificadop.PROD_MARCA;
                producto.PROD_CADUCIDAD = productoModificadop.PROD_CADUCIDAD;
                producto.PROD_PRECIOVEN = productoModificadop.PROD_PRECIOVEN;
                producto.PROD_PRECIOCOM = productoModificadop.PROD_PRECIOCOM;
                producto.PROD_IMAGEN = productoModificadop.PROD_IMAGEN;

                _contexto.SaveChanges();
                return producto.PROD_CODIGO;
            }
            return "No encontrado";
        }

        public string eliminarProducto(string codigo)
        {
            try
            {
                var producto = _contexto.PRODUCTO.FirstOrDefault(c => c.PROD_CODIGO == codigo);
                if (producto != null)
                {
                    _contexto.PRODUCTO.Remove(producto);
                    _contexto.SaveChanges();
                    return producto.PROD_CODIGO;
                }
                return "No encontrado";
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.InnerException is SqlException sqlEx)
                {
                    // Aquí puedes manejar específicamente la excepción de SQL
                    return "No se puede eliminar el producto porque está en uso.";
                }
                // Puedes retornar un mensaje general si la excepción no es una SqlException
                return "Error al eliminar el producto.";
            }
            catch (Exception ex)
            {
                // Este es un bloque de captura general para cualquier otro tipo de excepción no prevista
                return "Error al procesar la solicitud.";
            }
        }
        #endregion

    }
}