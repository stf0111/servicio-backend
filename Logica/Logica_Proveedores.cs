using Acceso_Datos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica
{
    public class Logica_Proveedores
    {
        Datos_Proveedores op = new Datos_Proveedores();

        public List<PROVEEDOR> SeleccionarProveedores()
        {
            return op.SeleccionarProveedores();
        }

        public PROVEEDOR SeleccionarProveedorPorCodigo(string provCod)
        {
            return SeleccionarProveedores().Where(p => p.PROV_COD == provCod).SingleOrDefault();
        }

        public string insertarProveedor(PROVEEDOR nuevoProveedor)
        {
            return op.insertarProveedor(nuevoProveedor);
        }

        public string modificarProveedor(PROVEEDOR proveedorModificado)
        {
            return op.modificarProveedor(proveedorModificado);
        }

        public string eliminarProveedor(string codigo)
        {
            return op.eliminarProveedor(codigo);
        }
    }
}
