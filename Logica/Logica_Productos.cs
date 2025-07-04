using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica_Productos
    {
        Datos_Productos op = new Datos_Productos();

        public List<PRODUCTO> SeleccionarProducto()
        {
            return op.SeleccionarProducto();

        }

        public PRODUCTO SeleccionarProductoPorCod(string codigoPRODp)
        {
            return SeleccionarProducto().Where(cat => cat.PROD_CODIGO == codigoPRODp).SingleOrDefault();
        }

        public List<PRODUCTO> SeleccionarProductoPorMarca(string marcaPRODp)
        {
            return SeleccionarProducto().Where(cat => cat.PROD_MARCA == marcaPRODp).ToList();
        }


        public List<PRODUCTO> SeleccionarProductoPorTipo(string tipoPRODp)
        {
            return SeleccionarProducto().Where(cat => cat.PROD_TIPO == tipoPRODp).ToList();
        }

        public string insertarProducto(PRODUCTO nuevoPRODp)
        {
            return op.insertarProducto(nuevoPRODp);
        }


        public string modificarProducto(PRODUCTO productoModificadop)
        {
            // Delega la modificación a la capa de datos
            return op.modificarProducto(productoModificadop);
        }

        public string eliminarProducto(string codigoProductop)
        {
            // Delega la eliminación a la capa de datos
            return op.eliminarProducto(codigoProductop);
        }

    }
}
